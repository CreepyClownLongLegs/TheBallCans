using Inventory.Model;
using Systems.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ItemLocationModifierSO : RoomModifierSO
{
    public readonly SceneGroupManager manager = new SceneGroupManager();
    [SerializeField] GameObject chair;

    GameObject chairParent;

    public override void AffectRoom(GameObject character, PlaceableItemSO item, Vector3 coords)
    {
        //TODO: code position where to place item
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        
        if (SceneLoader.Instance.loadedScenes.Contains("YourRoomUI"))
        {
            chairParent = GameObject.FindGameObjectWithTag("chairParent");
            chairParent.transform.position = coords;
            //place item in the scene
            Instantiate(chair, chairParent.transform);
        }
        else
        {
            NotificationManager.Instance.showNotification("You cannot place that item here.", NotificationPanelColor.INFO);
        }
        
    }
}
