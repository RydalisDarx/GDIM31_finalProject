using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }//end if there is already an instance of singleton
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }//end awake

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }//end OnEnable subscription

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAll();
        LoadGame();
    }//end OnSceneLoaded

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }//end OnDisable unsubscription
    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }//end OnSceneUnloaded


    private void OnApplicationQuit()
    {
        SaveGame();
    }//end OnApplicationQuit 
    public void NewGame()
    {
        this.gameData = new GameData();
    }//end newGame

    public void LoadGame()
    {
        //load any saved data from a file using the dataHandler
        this.gameData = dataHandler.Load();

        //if there is no data, force user to make new game
        if(this.gameData == null)
        {
            return;
        }//if there is no game to load then start a new game

        //push loaded data into scripts that need it
        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.LoadData(gameData);
        }//end foreach
    }//end LoadGame

    public void SaveGame()
    {
        if(this.gameData == null)
        {
            return;
        }//if there is no data to save, return


        //pass data to scripts to update it
        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.SaveData(ref gameData);
        }//end foreach 

        dataHandler.Save(gameData);
    }//end SaveGame

    private List<IDataPersistence> FindAll()
    {
        //find all objects of type MonoBehaviour that extends IDataPersistence
        IEnumerable<IDataPersistence> dataPersistenceObj = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObj);
    }//end find all data persistence objects
}//end dataPersistenceManager
