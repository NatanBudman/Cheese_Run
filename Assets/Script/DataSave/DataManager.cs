using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   // public LevelsDataManager _LevelDataManager;
    
    public List<string> AllUserRegister = new List<string>();
    private int UserUpdate ;
    public string PlayerName;
    public string PlayerPassword;
    public int AllPlayerStars;

    public int PreviusAllPlayerStars;
    
    
    private void Start()
    {
        DontDestroyOnLoad(this);
        
        UserUpdate = SaveDataManager.PlayersRegister;
        
        for (int i = 0; i < SaveDataManager.PlayersRegister - 1; i++)
        {
            AllUserRegister.Add(SaveDataManager.PlayerNames[i]);
        }

    }

    private void Update()
    {
        if (UserUpdate != SaveDataManager.PlayersRegister)
        {
            for (int i = UserUpdate; i < SaveDataManager.PlayersRegister - 1; i++)
            {
                AllUserRegister.Add(SaveDataManager.PlayerNames[i]);
                UserUpdate++;
            }
        }

        if (AllPlayerStars != PreviusAllPlayerStars && PlayerName != String.Empty)
        {
            UpdateDate();
        }
    }

    void UpdateDate()
    {
        SaveDataManager.SavePlayerData(this);

    }
    
    public bool IsHaveAccountRegister() =>  PlayerName != String.Empty;
}
