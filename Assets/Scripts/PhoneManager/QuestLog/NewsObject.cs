
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class NewsObject : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI source;
    [SerializeField] GameObject watchVideoButton;
    [SerializeField] GameObject newsVideoPlayer;
    private VideoClip video;
    private EventReference audio;

    void Start(){
        exitVideo();
    }
    public void CreateNewsWithoutVideo(string title, string description, string source){
        this.title.text = "Breaking :" + title;
        this.description.text = description;
        this.source.text = "Source: " + source;
        watchVideoButton.SetActive(false);
        newsVideoPlayer.SetActive(false);
    }

    public void CreateNewsWithVideo(string title, string description, string source, VideoClip video, EventReference audio){
        this.title.text = "Breaking :" + title;
        this.description.text = description;
        this.source.text = "Source: " + source;
        this.video = video;
        this.audio = audio;
        watchVideoButton.SetActive(true);
        newsVideoPlayer.SetActive(false);
    }

    public void PlayVideo(){
        newsVideoPlayer.SetActive(true);
        newsVideoPlayer.GetComponent<VideoPlayer>().clip = video;
        NewsLogScrollingList.instance.videoCanvas.SetActive(true);
        newsVideoPlayer.GetComponent<VideoPlayer>().Play();
        AudioManager.instance.InitializeMusic(this.audio);
    }

    public void exitVideo(){
        newsVideoPlayer.GetComponent<VideoPlayer>().Stop();
        newsVideoPlayer.SetActive(false);
        NewsLogScrollingList.instance.videoCanvas.SetActive(false);
    }
}
