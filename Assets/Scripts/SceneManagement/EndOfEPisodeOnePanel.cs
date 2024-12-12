using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOfEPisodeOnePanel : MonoBehaviour
{
    private GameObject endOfEpisodeOnePanel;
    private TextMeshProUGUI text;
    string sleepingText = "zzZZzzZZ <br> zzZZZZzz";
    string EpisodeTwoText = "Begin Of Episode Two: <br> You ain't so bad kid";
    string YouveCompletedTheGameText = "CONGRATULATIONS! <br> You've completed the game <br>";
    public float sleepingTimer = 2f;
    public float fadeInOutTime = 5f;
    Color black = Color.black;
    public float timer = 0f;
    public int frequinceOfText = 5;
    bool isAddingRichTextTag = false;
    int i = 0;
    int j=0;
    public static event Action endOfGame;
    // Start is called before the first frame update
    private void Start()
    {
        endOfEpisodeOnePanel = this.gameObject;
        text = GetComponentInChildren<TextMeshProUGUI>();
        if(EpisodeManager.instance.EpisodeTwoRhytmGameFinished){
            //end of game
            this.endOfEpisodeOnePanel.GetComponentInChildren<TextMeshProUGUI>().text = "";
            EpisodeTwoText = YouveCompletedTheGameText;
            //checking for ending type
            if(DataPersistenceManager.instance.GetExpirience() < 100){
                EpisodeTwoText += "Ending 1 of 3 : 'Kindred Spirits'";
            }else if ((100 <= DataPersistenceManager.instance.GetExpirience()) 
            &&  DataPersistenceManager.instance.GetExpirience() < 180){
                EpisodeTwoText += "Ending 2 of 3 : 'Neighboars forever'";
            }else{
                EpisodeTwoText += "Ending 3 of 3 : 'We're glad you moved here'";               
            }
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
