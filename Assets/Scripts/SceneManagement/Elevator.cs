using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Elevator : PersistentSingleton<Elevator>
{
    [SerializeField] GameObject [] doors;
    [SerializeField] GameObject floorSelectionPanel;
    [SerializeField] GameObject EG_floor;

    public bool ElevatorPanelIsOpen = true;
    CharacterController2D characterController;
    // Start is called before the first frame update
    void Awake(){
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }
    void Start()
    {
        characterController.elevatorPanelIsOpen = ElevatorPanelIsOpen;
        foreach(GameObject door in doors){
            door.SetActive(false);
        }

        floorSelectionPanel.SetActive(true);
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(EG_floor);
    }

    public void SelectFloor(int floor){
        ElevatorPanelIsOpen = false;
        characterController.elevatorPanelIsOpen = ElevatorPanelIsOpen;
        floorSelectionPanel.SetActive(false);
        StartCoroutine(FloorSelected(floor));
    }

    private IEnumerator FloorSelected(int door){
        yield return new WaitForSeconds(1f);
        doors[door].SetActive(true);
    }
}
