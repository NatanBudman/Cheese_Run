using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<string> AllUserRegister = new List<string>();
    private int UsarUpdate ;
    public string PlayerName;
    public string PlayerPassword;
    public int AllPlayerStars;

    public int PreviusAllPlayerStars;
    
    private void Start()
    {
        DontDestroyOnLoad(this);
        
        UsarUpdate = SaveDataManager.PlayersRegister;
        
        for (int i = 0; i < SaveDataManager.PlayersRegister - 1; i++)
        {
            AllUserRegister.Add(SaveDataManager.PlayerNames[i]);
        }

    }

    private void Update()
    {
        if (UsarUpdate != SaveDataManager.PlayersRegister)
        {
            for (int i = UsarUpdate; i < SaveDataManager.PlayersRegister - 1; i++)
            {
                AllUserRegister.Add(SaveDataManager.PlayerNames[i]);
                UsarUpdate++;
            }
        }

        if (AllPlayerStars != PreviusAllPlayerStars && PlayerName != String.Empty)
        {
            SaveDataManager.SavePlayerData(this);
        }
    }
}
