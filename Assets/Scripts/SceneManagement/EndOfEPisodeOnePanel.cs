using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOfEPisodeOnePanel : MonoBehaviour
{
    private GameObject endOfEpisodeOnePanel;
    private TextMeshProUGUI text;
    string sleepingText = "zzZZzzZZ <br> zzZZZZzz";
    string EpisodeTwoText = "Begin Of Episode Two: <br> You ain't so bad kid";
    string YouveCompletedTheGameText = "CONGRATULATIONS! <br> You've completed the game <br> Ending : 1 of 3";
    public float sleepingTimer = 2f;
    public float fadeInOutTime = 5f;
    Color black = Color.black;
    public float timer = 0f;
    public int frequinceOfText = 5;
    bool isAddingRichTextTag = false;
    int i = 0;
    int j=0;
    // Start is called before the first frame update
    private void Start()
    {
        endOfEpisodeOnePanel = this.gameObject;
        text = GetComponentInChildren<TextMeshProUGUI>();
        if(EpisodeManager.instance.EpisodeTwoRhytmGameFinished){
            this.endOfEpisodeOnePanel.GetComponentInChildren<TextMeshProUGUI>().text = "";
            EpisodeTwoText = YouveCompletedTheGameText;
            sleepingTimer = 0f;
            fadeInOutTime = 6f;
        }
    }

    void FixedUpdate(){
        timer += 0.01f;
        if(timer > sleepingTimer && timer < (sleepingTimer + 0.5f)){
            ChangeColor();
        } 
        if(timer > (sleepingTimer + 0.5f) && timer < (sleepingTimer + 3f)){
            showSleepingText();
        } 
        if(timer > (sleepingTimer + 3f) && timer < (sleepingTimer + fadeInOutTime)){
            text.text = EpisodeTwoText;
        }
        if(timer > (sleepingTimer + fadeInOutTime)){
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>().elevatorPanelIsOpen = false;
            this.gameObject.SetActive(false);
        }
    }

    public void ChangeColor(){
        text.text = "";
        endOfEpisodeOnePanel.GetComponent<Image>().color = new Color(
                Color.black.r,
                Color.black.g,
                Color.black.b,
                Mathf.Lerp(0.2f, 1f, (timer-sleepingTimer)/ 0.3f)
        );
    }

    public void showSleepingText(){
        if(i >= frequinceOfText && j < sleepingText.Length){
            if (sleepingText[j] == '<' || isAddingRichTextTag) 
            {
            isAddingRichTextTag = true;
            if (sleepingText[j] == '>')
                {
                    isAddingRichTextTag = false;
                }
            }else {
                text.text += sleepingText[j]; 
            }
            j++;
            i = 0;
        }
        i++;
    }

}
