using System.Collections;
using System.Collections.Generic;
using Systems.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void ExitGame() 
    {
        Debug.Log("Quitting the game.");
        Application.Quit();
    }

    public void StartNewGame()
    {
           _ = SceneLoader.Instance.LoadSceneGroup(1);
    }
}
