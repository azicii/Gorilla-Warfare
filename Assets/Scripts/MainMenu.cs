using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject endGameMenu;
    [SerializeField] GameObject player;
    [SerializeField] float levelTime = 60f;

    void Update()
    {
        PauseMenuDetection();
        EndGameScreen();
    }

    private void PauseMenuDetection()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            optionsMenu.gameObject.SetActive(true);
        }
    }

    public void PlayNextScene()
    {
        Debug.Log("Scene # " + SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void EndGameScreen()
    {
        if (Time.timeSinceLevelLoad >= levelTime)
        {
            endGameMenu.gameObject.SetActive(true);

            player.GetComponent<PlayerControls>().enabled = false;
            player.GetComponent<CollisionHandler>().enabled = false;
        }
    }

}
