using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour, IDataPersistence
{
    public static int totalCollected; //public static total collectibles acquired

    public void LoadData(GameData data)
    {
        totalCollected = data.pantCount;
    }

    public void SaveData(ref GameData data)
    {
        data.pantCount = totalCollected;
    }
}
