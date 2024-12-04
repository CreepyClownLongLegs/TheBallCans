using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BeatScroller : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    public float beatTempoFirstRound = 120f;
    public float beatTempoSecondRound = 100f;
    private float scrollSpeed;
    private float GoalLine = -100f;
    public float GoalLineFirstRound = -10000f;
    public float GoalLineSecondRound = -10000f;
    public bool endCalled = false;
    // Start is called before the first frame update
    void Start()
    {

        if(EpisodeManager.instance.secondEpisode){
            scrollSpeed = beatTempoSecondRound*2;
            GoalLine = GoalLineSecondRound;
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            videoPlayer.clip = VideoFiles.instance.miPlesemoVideo;
        } else {
            scrollSpeed = beatTempoFirstRound*2;
            GoalLine = GoalLineFirstRound;
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
            videoPlayer.clip = VideoFiles.instance.suadaVideo;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!RhythmGameManager.Instance.scrollerScrolling){
            return;
        }
        this.transform.position -= new Vector3(0f, scrollSpeed*Time.unscaledDeltaTime, 0f);

        if(this.transform.position.y < GoalLine && !endCalled){
            endCalled = true;
            RhythmGameManager.Instance.EndGame();
        }
    }
}
