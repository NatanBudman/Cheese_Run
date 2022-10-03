using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public static class SaveDataManager
{
    public static List<string> PlayerNames  = new List<string>();
    public static int PlayersRegister ;
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
        PlayerNames.Add(NameUsing);
        PlayersRegister++;
        Debug.Log(NameUsing);
    }

    public static void SetNames()
    {
        PlayerPrefs.SetInt("PlayersRegister", PlayersRegister);
        Debug.Log(PlayersRegister);

        for (int i = 0; i < PlayersRegister - 1 ; i++)
        {
            Debug.Log(i);
            PlayerPrefs.SetString($"PlayerNames{i}",PlayerNames[i]);
        }
    }

    public static string GetName(int NameInList)
    {
        return PlayerPrefs.GetString($"PlayerNames{NameInList}");
    }

    public static void GetNames()
    {
        PlayersRegister = PlayerPrefs.GetInt("PlayersRegister");
        Debug.Log(PlayersRegister);

        for (int i = 0; i < PlayersRegister - 1; i++)
        {
            Debug.Log(i);
            PlayerNames.Add(PlayerPrefs.GetString($"PlayerNames{i}"));
        }
    }
    public static string VerificatedPlayerName(string nameVerificate)
    {
        for (int i = 0; i < PlayersRegister ; i++)
        {
            if (nameVerificate == GetName(i))
            {
                return null;
            }
           
        }
        return nameVerificate;
    }
}
[Serializable]
public class PlayerData
{
    public string PlayerName;
    public string PlayerPassword;
    public int AllCollectionPlayerStars;
    
    
    public PlayerData(DataManager playerData)
    {
        PlayerName = playerData.PlayerName;
        PlayerPassword = playerData.PlayerPassword;
        AllCollectionPlayerStars = playerData.AllPlayerStars;
    }
   
}

