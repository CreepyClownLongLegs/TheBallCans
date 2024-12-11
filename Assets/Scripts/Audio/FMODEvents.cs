using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Item SFX")]
    [field: SerializeField] public EventReference itemCollected {get; private set;} 
    [field: SerializeField] public EventReference kick {get; private set;} 
    [field: SerializeField] public EventReference ouch {get; private set;}
    [field: SerializeField] public EventReference snare {get; private set;} 
    [field: SerializeField] public EventReference ourRoomTheme {get; private set;} 
    [field: SerializeField] public EventReference serbiaTheme {get; private set;} 
    [field: SerializeField] public EventReference romaniaTheme {get; private set;} 
    [field: SerializeField] public EventReference HallwayTheme {get; private set;} 
    [field: SerializeField] public EventReference LobbyTheme {get; private set;} 
    [field: SerializeField] public EventReference ElevatorTheme {get; private set;} 
    [field: SerializeField] public EventReference restaurantTheme {get; private set;} 
    [field: SerializeField] public EventReference kayakingMiniGameTheme {get; private set;} 
    [field: SerializeField] public EventReference suada {get; private set;} 
    [field: SerializeField] public EventReference miPlesemo {get; private set;} 
    [field: SerializeField] public EventReference kayakingVideo {get; private set;} 
    [field: SerializeField] public EventReference spotLightVideo {get; private set;} 
    [field: SerializeField] public EventReference pljeskavicaVideo {get; private set;}
    [field: SerializeField] public EventReference sleepingSFX {get; private set;} 

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
