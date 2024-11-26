using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Item SFX")]
    [field: SerializeField] public EventReference itemCollected {get; private set;} 
    [field: SerializeField] public EventReference kick {get; private set;} 
    [field: SerializeField] public EventReference snare {get; private set;} 
    [field: SerializeField] public EventReference ourRoomTheme {get; private set;} 
    [field: SerializeField] public EventReference suada {get; private set;} 

    public static FMODEvents instance {get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than once FMOD Events instance in the scene.");
        }
        instance = this;
    }
}
