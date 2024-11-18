using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : PersistentSingleton<PhoneManager>
{
    [SerializeField] GameObject Phone;
    // Start is called before the first frame update
    public static event Action QuestLogCalled;
    bool isActive = false;

    private void Start(){
        InputSystem.phoneCalled += togglePhone;
        Phone.SetActive(isActive);
    }

    private void OnDestroy(){
        InputSystem.phoneCalled -= togglePhone;
    }

    private void togglePhone(){
        isActive = !isActive;
        Phone.SetActive(isActive);
        QuestLogCalled?.Invoke();
    }
}
