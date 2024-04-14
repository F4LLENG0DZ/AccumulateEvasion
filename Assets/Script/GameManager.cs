using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //Game Over components
    public Text gameOverText;
    public Text retryButtonText;
    public Text quitButtonText;

    public Text resumeButtonText;
    public Text quitToMenuButtonText;

    //Camera shake upon game over (temp fix)
    public CameraShake cameraShake;
    public float shakeIntensity = 0.5f;
    public float shakeDuration = 0.6f;

    //gameover button
    public Button retryButton;
    public Button quitButton;

    public Button resumeButton;
    public Button quitToMenuButton;

    bool gameHasEnded = false;
    bool gameIsPaused = false;

    UnityEvent restartEvent = new UnityEvent();
    UnityEvent quitEvent= new UnityEvent();
    void Start()
    {
        InitialState();
        restartEvent.AddListener(RestartOnButton);
        quitEvent.AddListener(QuitOnButton);
    }
    void Update()
    {
        if (gameHasEnded == true)
        {
            retryButtonText.enabled= true;
            quitButtonText.enabled= true;
        }
        if (gameIsPaused == true && gameHasEnded == false && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
        if (gameIsPaused == false && gameHasEnded == false && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void EndGame() 
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverText.enabled= true;
            retryButton.enabled = true;
            quitButton.enabled = true;
            Debug.Log("Game over");
            gameOverText.text = "GAME OVER";
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeIntensity));
        }
    }
    public void PauseGame() 
    {
        Time.timeScale = 0.0f;
        FindObjectOfType<Player>().Froze();
        resumeButton.enabled = true;
        resumeButtonText.enabled = true;
        quitToMenuButton.enabled = true;
        quitToMenuButtonText.enabled = true;
        gameIsPaused = true;
    }
    public void ResumeGame() 
    {
        if (gameIsPaused == true)
        {
            Time.timeScale = 1.0f;
            FindObjectOfType<Player>().UnFroze();
            resumeButton.enabled = false;
            resumeButtonText.enabled = false;
            quitToMenuButton.enabled = false;
            quitToMenuButtonText.enabled = false;
            gameIsPaused = false;
        }
    }
    public void RestartOnButton() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitOnButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
        restartEvent.RemoveListener(RestartOnButton);
        quitEvent.RemoveListener(QuitOnButton);
    }

    void InitialState()
    {
        Time.timeScale = 1.0f;
        gameOverText.enabled = false;
        retryButton.enabled = false;
        retryButtonText.enabled = false;
        quitButton.enabled = false;
        quitButtonText.enabled = false;
        resumeButton.enabled = false;
        resumeButtonText.enabled = false;
        quitToMenuButton.enabled = false;
        quitToMenuButtonText.enabled = false;
    }
}
