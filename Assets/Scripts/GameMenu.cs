using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    Transform Player;
    Transform SpawnPoint;
    ThirdPersonMovement thirdPersonMovement;
    private Canvas gameOverscreen;
    private Canvas stageCompleteScreen;
    private Canvas pauseScreen;
    public bool isPaused;
    InputManager inputManager;

    void Start()
    {
        Time.timeScale = 1;
        Player = GameObject.Find("Mon").GetComponent<Transform>();
        gameOverscreen = GameObject.Find("GameOver").GetComponent<Canvas>();
        stageCompleteScreen = GameObject.Find("StageComplete").GetComponent<Canvas>();
        pauseScreen = GameObject.Find("PauseScreen").GetComponent<Canvas>();
        thirdPersonMovement = Player.GetComponent<ThirdPersonMovement>();
        SpawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        gameOverscreen.enabled = true;
        PauseGame();
    }

    public void StageComplete()
    {
        stageCompleteScreen.enabled = true;
        PauseGame();
    }

    public void NextStage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void HandlePauseScreen()
    {
        pauseScreen.enabled = !pauseScreen.enabled;
        Time.timeScale = pauseScreen.enabled ? 0 : 1;
    }
}
