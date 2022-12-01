using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int pantCount;

    //default values when game is started fresh
    public GameData()
    {
        this.pantCount = 0;
    }//end constructor

}//end gameData
