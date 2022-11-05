using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;  //You can ignore this for now - we will talk about Actions a bit later in this course.
   
    [SerializeField]
    private GameObject GameOverScreen; //A reference to the GameObject that is the GameOver UI Screen


    private static GameStateManager _instance; //This class is a Singleton - We will also discuss this pattern later in this class.





    // Start is called before the first frame update
    void Start()
    {
        //Setup for making this class a Singlton - Don't modify this part of the code.
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }


        //Put other inialization for you game state here


    }


    //These two methods help up to handle the Game being over and restarting. 
    public static void GameOver()
    {

        //Add any logic that you would want to do when the game ends here

        //This invokes the game over screen - here we are calling all the methods that subscribed to this action. 
        SceneManager.LoadScene(0);

    }

    public static void Restart()
    {
        //Add code here to restart the game
        SceneManager.LoadScene(0); //menu
    }

}