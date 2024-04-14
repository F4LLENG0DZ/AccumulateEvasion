using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEvent startGameOnButton = new UnityEvent();
    UnityEvent quitGameOnButton = new UnityEvent();


    void Start()
    {
        startGameOnButton.AddListener(StartGame);
        quitGameOnButton.AddListener(QuitGame);
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("Scene1");
        startGameOnButton.RemoveListener(StartGame);
    }

    public void QuitGame() 
    {
        Application.Quit();
        startGameOnButton.RemoveListener(StartGame);
        quitGameOnButton.RemoveListener(QuitGame);
    }
}
