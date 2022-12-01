using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false; //Is the game paused?
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //user presses escape to pause
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() //Resume game
    {
        pauseMenuUI.SetActive(false); //no menu
        Time.timeScale = 1f; //normal time
        isPaused = false;
    }

    void Pause() //Pause game
    {
        pauseMenuUI.SetActive(true); //show menu
        Time.timeScale = 0f; //freeze time
        isPaused = true;
    }

    public void loadMenu() //Load scene(0) or menu scene
    {
        Time.timeScale = 1f; //unfreeze time
        SceneManager.LoadScene(0);
    }

    public void quitGame() //Quit game
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
