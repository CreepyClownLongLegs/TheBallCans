using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject{
    [field : SerializeField] public string id {get;private set;}

    [Header("General")]
    public string displayName;
    public string description = "Quest";

    [Header("Requirements")]

    public QuestInfoSO[] questPrerequirements;
    public GameObject[] questStepPrefabs;

    [Header("Rewards")]
    public int coins;
    public int playerExpirience;

    private void OnValidate(){
        #if UNITY_EDITOR
            id = this.name;
            UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
