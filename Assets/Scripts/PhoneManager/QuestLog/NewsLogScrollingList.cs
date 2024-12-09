using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class NewsLogScrollingList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;

    [Header("Rect Transforms")]
    [SerializeField] private RectTransform scrollRectTransform;
    [SerializeField] private RectTransform contentRectTransform;

    [Header("Quest Log Button")]
    [SerializeField] private GameObject newsPrefab;
    [SerializeField] public GameObject videoCanvas;
    public static NewsLogScrollingList instance;

    void Awake(){
        if(instance != null){
            Destroy(instance);
        }

        instance = this;
    }

    void Start(){
        videoCanvas.SetActive(false);
        //CreateNewsWithVideo("NEws", "Watch the video dumbass", "justdoit.com", VideoFiles.instance.kayakingVideo, FMODEvents.instance.kayakingVideo);
    }
    public void CreateNewsWithoutVideo(string title, string description, string source){
        GameObject news = Instantiate(newsPrefab, contentParent.transform);
        news.GetComponent<NewsObject>().CreateNewsWithoutVideo(title, description, source);
        news.transform.SetAsFirstSibling();
        UpdateScrolling(news.GetComponent<RectTransform>());
    }
    public void CreateNewsWithVideo(string title, string description, string source, VideoClip video, EventReference audio){
        GameObject news = Instantiate(newsPrefab, contentParent.transform);
        news.GetComponent<NewsObject>().CreateNewsWithVideo(title, description, source, video, audio);
        news.transform.SetAsFirstSibling();
        UpdateScrolling(news.GetComponent<RectTransform>());
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
