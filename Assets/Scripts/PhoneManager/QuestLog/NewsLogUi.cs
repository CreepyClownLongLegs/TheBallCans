
using UnityEngine;

public class NewsLogUi : MonoBehaviour
{
    [SerializeField] NewsLogScrollingList scrollingList;
    //To Show News Panel
    [SerializeField] GameObject contentParent;
    [SerializeField] QuestLogUI contentParentQuestLog;
    // Start is called before the first frame update
    void Start()
    {
        HideNewsLogUI();
    }

    public void showNewsLog(){
        this.contentParent.SetActive(true);
        EpisodeManager.instance.YouveGotNewsPanel.SetActive(false);
        contentParentQuestLog.HideUI();
    }

    public void HideNewsLogUI(){
        this.contentParent.SetActive(false);
    }
}
