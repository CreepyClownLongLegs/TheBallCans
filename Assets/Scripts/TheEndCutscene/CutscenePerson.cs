using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePerson : MonoBehaviour
{
    [SerializeField] private string name;
    // Start is called before the first frame update
    void Start()
    {
        if(!EpisodeManager.instance.contacts.ContainsKey(name)){
            this.gameObject.SetActive(false);
        }
    }


}
