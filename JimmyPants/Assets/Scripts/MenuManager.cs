using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour, IDataPersistence
{
    private int sceneNext;
    public void StartGame()
    {
        //Starts a new game
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(sceneNext);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
   
    public void LoadData(GameData data)
    {
        if(data.pantCount <= 3)
        {
            sceneNext = data.pantCount + 1;
        } else
        {
            sceneNext = 3;
        }
    }

    public void SaveData(ref GameData data)
    {
        
    }
}