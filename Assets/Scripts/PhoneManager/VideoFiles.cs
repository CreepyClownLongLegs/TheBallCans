using UnityEngine;
using UnityEngine.Video;

public class VideoFiles : MonoBehaviour
{
    [field : Header("newsVideos")]
    [SerializeField] public VideoClip kayakingVideo;
    [SerializeField] public VideoClip spotLightVideo;
    [SerializeField] public VideoClip suadaVideo;
    [SerializeField] public VideoClip miPlesemoVideo;
    [SerializeField] public VideoClip pljeskavicaVideo;
    public static VideoFiles instance {private set; get;}
    void Awake()
    {
        if(instance != null){
            Destroy(instance);
        }
        instance = this;
    }
}
