using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;
    public static GameData currentGame;

    void Awake()
    {
        // Load game on start
        if (instance == null)
        {
            instance = this;
            LoadGame();
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveGameData.gd");
        bf.Serialize(file, currentGame);
        file.Close();

        currentGame.Print();
    }

    public static void LoadGame()
    {
        // Load save game if it exists
        if ( File.Exists(Application.persistentDataPath + "/saveGameData.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveGameData.gd", FileMode.Open);
            currentGame = (GameData)bf.Deserialize(file);
            file.Close();

        } else
        {
            currentGame = new GameData();
        }
        currentGame.Print();
    }

    public static int GetTotalStars()
    {
        int totalStars = 0;

        for(int i = 0; i < currentGame.cubesPerLevel.Length; i++)
        {
            totalStars += currentGame.cubesPerLevel[i];
        }

        return (totalStars);
    }
    
}
