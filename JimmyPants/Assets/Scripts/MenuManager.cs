using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /*
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
    */
    public void Awake()
    {
        //This object is subcribing to that Action in the Game State Manager. We will talk about this more indepth later in the Quarter and in GDIM 32
        GameStateManager.OnGameOver += Open;

        //Make sure this object is not visible when the game starts
        gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        //Because the Game State Manager is going to persist across scene loads & reloads, we need to make sure that when this object goes away it unsubscribes from the action first.
        GameStateManager.OnGameOver -= Open;
    }

    private void Open()
    {
        //Show the menu
        gameObject.SetActive(true);
        //Do any other menu opening code.

    }

    public static void Quit()
    {
        //quit the application
        Application.Quit();
    }
}