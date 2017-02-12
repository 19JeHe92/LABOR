using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//This class is responsible for managing information about the games state which needs to be persisted 
public class GameDataManager : MonoBehaviour {

    //Data to be saved
    public float playerHealth;
    public List<Checkpoints> checkpoints;
    public Inventory inventory;

    //DataManager is sort of a singleton so we make sure we have the same instance in all scenes
    public static GameDataManager dataManager;
	void Awake () {
        if (dataManager == null)
        {
            DontDestroyOnLoad(gameObject);
            dataManager = this;
        }
        else if (dataManager != this)
        {
            Destroy(gameObject);
        }
	}
	
    //Tha game data will be saved in binary file under a super secret path
	public void SaveGame()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "/LABOR.dat");

        GameData dataTobeSaved = new GameData();
        dataTobeSaved.playerHealth = playerHealth;
        dataTobeSaved.checkpoints = checkpoints;
        dataTobeSaved.inventory = inventory;

        binaryFormatter.Serialize(fileStream, dataTobeSaved);
        fileStream.Close();
    }

    //The saved data (if exists) will be loaded from the binary file and will be deserialized,
    //Finally the data managers data is set to the loaded data
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/LABOR.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/LABOR.dat", FileMode.Open);
            GameData loadedData = (GameData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            dataManager.playerHealth = loadedData.playerHealth;
            dataManager.checkpoints = loadedData.checkpoints;
            dataManager.inventory = loadedData.inventory;
        }
    }

    //Class needed to be able to serialize the game data
    [Serializable]
    class GameData
    {
        public float playerHealth;
        public List<Checkpoints> checkpoints;
        public Inventory inventory;
    }
}
