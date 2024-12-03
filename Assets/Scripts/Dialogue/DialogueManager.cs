using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueManager : PersistentSingleton<DialogueManager>
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Animator layoutAnimator;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    //just some variables
    public bool EpisodeOneKayakingGameFinished = false;
    public bool EpisodeOneCookingGameFinished = false;
    public bool CookingQuestAccepted = false;
    public bool GotPasswordFromFatima = false;
    public bool hasIron = false;
    public bool hasSpoon = false;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string AUDIO_TAG = "audio";
    private const string ITEM_TAG = "item";

    private Story currentStory;
    public bool dialogueIsPlaying { get; set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;
    private DialogueVariables dialogueVariables;
    private InkExternalFunctions inkExternalFunctions;

    private void Awake(){
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
        inkExternalFunctions = new InkExternalFunctions();
    }

    private void Update(){
        if(!dialogueIsPlaying) return;
        if(!currentStory.canContinue) continueIcon.SetActive(false);

        if (currentStory.currentChoices.Count == 0 
            && Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }
    }

    private void Start(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        continueIcon.SetActive(false);

        // get all of the choices text 
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) 
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        //remove later
        NotificationManager.Instance.showNotification("You've just moved in. So you obviously have to connect you PC to the Wifi first.", NotificationPanelColor.INFO);
    }


    public void EnterDialogueMode(TextAsset inkJSONText){
        currentStory = new Story(inkJSONText.text);

        
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        dialogueVariables.StartListening(currentStory);
        inkExternalFunctions.Bind(currentStory);

        ContinueStory();
    }


    public IEnumerator ExitDialogueMode() 
    {
        yield return new WaitForSeconds(0.1f);
        dialogueVariables.StopListening(currentStory);
        inkExternalFunctions.Unbind(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        // go back to default audio
    }


    private void ContinueStory(){
        if(dialogueIsPlaying){
            if(currentStory.canContinue){
                    if(EpisodeOneKayakingGameFinished){
                    Debug.Log("Finished Kayaking Game " + EpisodeOneKayakingGameFinished);
                    TrySetInkStoryVariable("EPISODE_ONE_FINISHED_KAYAKING_GAME","true");
                    EpisodeManager.instance.EpisodeOneKayakingGameFinished = true;
                    }
                    if(EpisodeOneCookingGameFinished){
                    TrySetInkStoryVariable("EPISODE_ONE_FINISHED_COOKING_GAME","true");     
                    EpisodeManager.instance.EpisodeOneCookingGameFinished = true;                  
                    }
                    if(CookingQuestAccepted){
                    TrySetInkStoryVariable("ACCEPTED_QUEST_YET","true");
                    EpisodeManager.instance.CookingQuestAcceptedEpisodeOne = true;
                    }
                    if (hasIron)
                    {
                        TrySetInkStoryVariable("HAS_IRON", "true");
                    }
                    if (!hasIron)
                    {
                        TrySetInkStoryVariable("HAS_IRON", "false");
                    }
                    if(hasSpoon)
                    {
                        TrySetInkStoryVariable("HAS_SPOON","true");
                    }
                    if(!hasSpoon)
                    {
                        TrySetInkStoryVariable("HAS_SPOON","false");
                    }
                dialogueText.text = currentStory.Continue();
                DisplayChoices();
                HandleTags(currentStory.currentTags);
                continueIcon.SetActive(true);
            }else {
        StartCoroutine(ExitDialogueMode());
        }
        }
    }

    private void DisplayChoices() 
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        HideChoices();
        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices) 
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    public void changeVariable(string name, object value){
        dialogueVariables.SetVariable(name,value, new Story(loadGlobalsJSON.text));
    }

        public bool TrySetInkStoryVariable(string variable, object value, bool log = true ){

            if(!currentStory){
                Debug.Log("Current story isnt loaded");
                return false;
            }

            if( currentStory != null &&
                currentStory.variablesState.GlobalVariableExistsWithName( variable ) )
            {
                if( log )
                {
                    Debug.Log( $"[Ink] Set variable: {variable} = {value}" );
                }

                currentStory.variablesState[variable] = value;

                return true;
            }

            return false;
        }

        private void HandleTags(List<string> currentTags)
    {
        // loop through each tag and handle it accordingly
        foreach (string tag in currentTags) 
        {
            // parse the tag
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2) 
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            
            // handle the tag
            switch (tagKey) 
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case AUDIO_TAG: 
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    private void HideChoices() 
    {
        foreach (GameObject choiceButton in choices) 
        {
            choiceButton.SetActive(false);
        }
    }

    private IEnumerator SelectFirstChoice() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {

            currentStory.ChooseChoiceIndex(choiceIndex);
            // NOTE: The below two lines were added to fix a bug after the Youtube video was made
            InputSystem.Instance.RegisterSubmitPressed(); // this is specific to my InputManager script
            StartCoroutine(WaitForChoice());
    }

    private IEnumerator WaitForChoice(){
        yield return new WaitForSeconds(0.1f);
    }

}
