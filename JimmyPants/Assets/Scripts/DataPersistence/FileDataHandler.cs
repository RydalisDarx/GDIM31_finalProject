using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = ""; //directory for data to save to
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }//end constructor

    public GameData Load()
    {
        //path.combine allows us to get the file on any directory OS
        string path = Path.Combine(dataDirPath, dataFileName);
        GameData loadData = null;
        if (File.Exists(path))
        {
            try
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using(StreamReader read = new StreamReader(stream))
                    {
                        dataToLoad = read.ReadToEnd();
                    }//end reading
                }//close input stream

                //deserialize data from JSON
                loadData = JsonUtility.FromJson<GameData>(dataToLoad);
            } catch (Exception e)
            {
                Debug.LogError("Error occured when trying to save data to file: " + path + "\n" + e);
            }//end try catch if file does not exist
        }//end if file exists in directory
        return loadData;
    }//end Load
    public void Save(GameData data)
    {
        //path.combine allows us to get the file on any directory OS
        string path = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create directory if it does not already exist
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            //serialize into JSON and write to file
            string storeData = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(stream))
                {
                    write.Write(storeData);
                }//end writing
            }//close output stream 
        } catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + path + "\n" + e);
        }//end try catch if file does not exist
    }//end save
}//end FileDataHandler
