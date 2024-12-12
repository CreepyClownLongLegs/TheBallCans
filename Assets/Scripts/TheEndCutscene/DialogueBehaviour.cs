using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueBehaviour : PlayableBehaviour
{
    public TextAsset inkJSON;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextAsset text  = playerData as TextAsset;
        if(!DialogueManager.Instance.dialogueIsPlaying) {
            DialogueManager.Instance.EnterDialogueMode(text);
        }
    }
}
