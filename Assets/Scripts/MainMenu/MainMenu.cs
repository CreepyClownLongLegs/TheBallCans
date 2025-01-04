
using Systems.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{


    public void ExitGame() 
    {
        Debug.Log("Quitting the game.");
        Application.Quit();
    }

    public void StartNewGame()
    {
           _ = SceneLoader.Instance.LoadSceneGroup(0);
           gameObject.SetActive(false);
    }
}
