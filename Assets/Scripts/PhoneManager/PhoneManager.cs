using System;
using UnityEngine;

public class PhoneManager : PersistentSingleton<PhoneManager>
{
    [SerializeField] GameObject Phone;
    [SerializeField] public GameObject videoCanvas;
    [SerializeField] public GameObject exitVideoButton;
    // Start is called before the first frame update
    public static event Action QuestLogCalled;
    bool isActive = false;

    private void Start(){
        InputSystem.phoneCalled += togglePhone;
        Phone.SetActive(isActive);
        videoCanvas.SetActive(false);
    }

    void FixedUpdate(){
        if(videoCanvas.activeInHierarchy){
            exitVideoButton.SetActive(true);
        }else{
            exitVideoButton.SetActive(false);
        }
    }

    private void OnDestroy(){
        InputSystem.phoneCalled -= togglePhone;
    }

    private void togglePhone(){
        isActive = !isActive;
        Phone.SetActive(isActive);
        QuestLogCalled?.Invoke();
    }

    public void exitVideo(){
        videoCanvas.SetActive(false);
        AudioManager.instance.SetCurrentSceneSound();
    }
}
