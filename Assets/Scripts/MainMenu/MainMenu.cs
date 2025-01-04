
using System.Collections;
using System.Collections.Generic;
using Systems.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button loadGameButton;

    private void Start()
    {
        DisableButtonsDependingOnData();
    }

    private void DisableButtonsDependingOnData() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

    public void ExitGame() 
    {
        Debug.Log("Quitting the game.");
        Application.Quit();
    }

    public void OnNewGameClicked() 
    {
        saveSlotsMenu.ActivateMenu(false);
        //this.DeactivateMenu();
    }

    public void StartNewGame()
    {
           _ = SceneLoader.Instance.LoadSceneGroup(0);
           gameObject.SetActive(false);
    }

}
