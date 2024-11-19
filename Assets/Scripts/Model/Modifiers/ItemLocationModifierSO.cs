using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using Systems.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ItemLocationModifierSO : RoomModifierSO
{
    public readonly SceneGroupManager manager = new SceneGroupManager();
    [SerializeField] GameObject chair;
    private GameObject parent;

    public override void AffectRoom(GameObject character, PlaceableItemSO item, Vector3 coords)
    {
        //TODO: code position where to place item
        
        if (SceneLoader.Instance.loadedScenes.Contains("YourRoomUI"))
        {
            parent = GameObject.FindGameObjectWithTag("ChairParent");
            //place item in the scene
            Instantiate(chair, parent.transform);
        }
        else
        {
            NotificationManager.Instance.showNotification("You cannot place that item here.", NotificationPanelColor.INFO);
        }
        
    }
}
