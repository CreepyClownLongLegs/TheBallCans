using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsUI : MonoBehaviour
{
    [SerializeField] ContactsScrollingList scrollingList;
    //To Show News Panel
    [SerializeField] NewsLogUi contentParentNews;
    [SerializeField] QuestLogUI contentParentQuestLog;
    [SerializeField] GameObject contentContacts;
    // Start is called before the first frame update
    void Start()
    {
        HideContactsUI();
    }

    public void showContactsLog(){
        this.contentContacts.SetActive(true);
        contentParentNews.HideNewsLogUI();
        contentParentQuestLog.HideUI();
    }

    public void HideContactsUI(){
        this.contentContacts.gameObject.SetActive(false);
    }
}
