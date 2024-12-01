using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFiles : MonoBehaviour
{
    [field : Header("newsVideos")]
    [SerializeField] public VideoClip kayakingVideo;
    public static VideoFiles instance {private set; get;}
    void Awake()
    {
        if(instance != null){
            Destroy(instance);
        }
        instance = this;
    }
}
