using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Systems.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float ambienceVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;

    private Bus masterBus;
    private Bus musicBus;
    private Bus ambienceBus;
    private Bus sfxBus;

    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;
    private EventInstance ambienceEventInstance;
    public EventInstance musicEventInstance;
    public EventInstance suadaEventInstance;
    public EventInstance miPlesemoEventInstance;
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }

    private void Start()
    {
        InitializeMusic(FMODEvents.instance.ourRoomTheme);
        SceneLoader.newSceneGrouploaded += SetCurrentSceneSound;
    }

    private void Update()
    {
        masterBus.setVolume(masterVolume);
        musicBus.setVolume(musicVolume);
        ambienceBus.setVolume(ambienceVolume);
        sfxBus.setVolume(SFXVolume);
    }

    private void InitializeAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    public void InitializeMusic(EventReference musicEventReference)
    {
        StopSong(musicEventInstance);
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

    public EventInstance InitializeSuada()
    {
        suadaEventInstance = CreateInstance(FMODEvents.instance.suada);
        return suadaEventInstance;
    }

    public EventInstance InitializeMiPlesemo()
    {
        miPlesemoEventInstance = CreateInstance(FMODEvents.instance.miPlesemo);
        return miPlesemoEventInstance;
    }

    public void SetAmbienceParameter(string parameterName, float parameterValue)
    {
        ambienceEventInstance.setParameterByName(parameterName, parameterValue);
    }


    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter;
    }

    private void CleanUp()
    {
        // stop and release any created instances
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
        // stop all of the event emitters, because if we don't they may hang around in other scenes
        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    public void SetCurrentSceneSound(){
        foreach(string scene in SceneLoader.Instance.loadedScenes){
            if(scene == "YourRoomUI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.ourRoomTheme);
            }
            if(scene=="SerbiaRoomUI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.serbiaTheme);
            }
            if(scene=="RomaniaRoom"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.romaniaTheme);
            }
            if(scene=="HallwayUI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.HallwayTheme);
            }
            if(scene=="Hallway1UI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.HallwayTheme);
            }
            if(scene=="TheLobbyUI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.LobbyTheme);
            }
            if(scene=="KitchenUI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.restaurantTheme);
            }
            if(scene=="ElevatorUI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.ElevatorTheme);
            }
            if(scene=="KayakingMiniGameUI"){
                StopSong(musicEventInstance);
                InitializeMusic(FMODEvents.instance.kayakingMiniGameTheme);
            }
        }
    }

    public void StopSong(EventInstance  eventInstance){
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    private void OnDestroy()
    {
        SceneLoader.newSceneGrouploaded -= SetCurrentSceneSound;
        CleanUp();
    }
}
