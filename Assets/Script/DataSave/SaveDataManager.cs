using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public static class SaveDataManager
{
    public static void SavePlayerData(DataManager playerDatas)
    {
        PlayerData playerData = new PlayerData(playerDatas);
        string dataPath = Application.persistentDataPath + $"/Player{playerDatas.PlayerName}.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream,playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerData(string playerName)
    {
        string dataPath = Application.persistentDataPath + $"/Player{playerName}.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData playerData = (PlayerData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData; 
        }
        else
        {
            Debug.Log("Dont Exist Data");
            return null;
        }
    }

    public static void AddPlayersNamesToListNameUsed( string NameUsing)
    {
        PlayerPrefs.SetString($"{NameUsing}", NameUsing);
    }

    public static string VerificatedPlayerName(string nameVerificate)
    {
        if (PlayerPrefs.HasKey(nameVerificate))
        {
            return null;
        }
        else
        {
            return nameVerificate;
        }
    }
}
[System.Serializable]
public class PlayerData
{
    public string PlayerName;
    public string PlayerPassword;
    
    
    public PlayerData(DataManager playerData)
    {
        PlayerName = playerData.PlayerName;
        PlayerPassword = playerData.PlayerPassword;
        
    }
   
}

