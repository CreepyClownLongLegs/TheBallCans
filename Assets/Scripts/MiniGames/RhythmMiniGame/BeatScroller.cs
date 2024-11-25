using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempoFirstRound = 120f;
    private float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = beatTempoFirstRound*2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!RhythmGameManager.Instance.scrollerScrolling){
            return;
        }
        this.transform.position -= new Vector3(0f, scrollSpeed*Time.unscaledDeltaTime, 0f);
    }
}
