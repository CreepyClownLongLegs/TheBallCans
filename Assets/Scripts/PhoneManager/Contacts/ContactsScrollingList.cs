
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ContactsScrollingList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;

    [Header("Rect Transforms")]
    [SerializeField] private RectTransform scrollRectTransform;
    [SerializeField] private RectTransform contentRectTransform;

    [Header("Contacts Button")]
    [SerializeField] private GameObject contactPrefab;
    public static ContactsScrollingList instance;

    public List<string> names = new List<string>();


    void Awake(){
        if(instance != null){
            Destroy(instance);
        }

        instance = this;
    }

    void Start(){
        //CreatecontactWithVideo("contact", "Watch the video dumbass", "justdoit.com", VideoFiles.instance.kayakingVideo, FMODEvents.instance.kayakingVideo);
        foreach(KeyValuePair<string,string> contact in EpisodeManager.instance.contacts){
            if(contact.Value != "Heads/"){
                //security for when contacts are not called before talking to first npc
                if(!names.Contains(contact.Key)){
                    CreateContactWithSprite(Resources.Load<Sprite>(contact.Value),contact.Key);
                }
            }
        }
    }

    public void CreateContact(Image contactIcon, string contactName){
        if(EpisodeManager.instance.contacts.ContainsKey(contactName)){
            return;
        }
        GameObject contact = Instantiate(contactPrefab
        , contentParent.transform);
        contact.GetComponent<ConactObject>().CreateContact(contactIcon, contactName);
        contact.transform.SetAsFirstSibling();
        EpisodeManager.instance.contacts.Add(contactName, "Heads/" + contactName);
        names.Add(contactName);
        UpdateScrolling(contact.GetComponent<RectTransform>());
    }

    //just at the beggining
    public void CreateContactWithSprite(Sprite contactIcon, string contactName){
        GameObject contact = Instantiate(contactPrefab
        , contentParent.transform);
        contact.GetComponent<ConactObject>().CreateContactWithSprite(contactIcon, contactName);
        contact.transform.SetAsFirstSibling();
        UpdateScrolling(contact.GetComponent<RectTransform>());
    }
    private void UpdateScrolling(RectTransform buttonRectTransform)
    {
        // calculate the min and max for the selected button
        float buttonYMin = Mathf.Abs(buttonRectTransform.anchoredPosition.y);
        float buttonYMax = buttonYMin + buttonRectTransform.rect.height;

        // calculate the min and max for the content area
        float contentYMin = contentRectTransform.anchoredPosition.y;
        float contentYMax = contentYMin + scrollRectTransform.rect.height;

        // handle scrolling down
        if (buttonYMax > contentYMax)
        {
            contentRectTransform.anchoredPosition = new Vector2(
                contentRectTransform.anchoredPosition.x,
                buttonYMax - scrollRectTransform.rect.height
            );
        }
        // handle scrolling up
        else if (buttonYMin < contentYMin) 
        {
            contentRectTransform.anchoredPosition = new Vector2(
                contentRectTransform.anchoredPosition.x,
                buttonYMin
            );
        }
    }
}
