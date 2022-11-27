using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreTDA _scoreTda;
    [SerializeField] private DataManager _dataManager;

    [SerializeField] private Text[] Positions = new Text[5];



    void Start()
    {
        _scoreTda.Initialization(SaveDataManager.PlayersRegister);

        for (int i = 0; i < Positions.Length; i++)
        {
            Positions[i].text = $"Position :{i} Player: " + _scoreTda.TopPlayer().PlayerName + " Score: " + _scoreTda.TopPlayer().AllCollectionPlayerStars;
            _scoreTda.UnstackPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshButton()
    {
        if (!_scoreTda.StackEmpty())
        {
            for (int i = 0; i < SaveDataManager.PlayersRegister - 1 ; i++)
            {
                String pj = _dataManager.AllUserRegister[i]; 
                _scoreTda.StackPlayers(SaveDataManager.LoadPlayerData(pj));
            }

            for (int i = 0; i < Positions.Length - 1; i++)
            {
                Positions[i].text = $"Position :{i} Player: " + _scoreTda.TopPlayer().PlayerName + " Score: " + _scoreTda.TopPlayer().AllCollectionPlayerStars;
                _scoreTda.UnstackPosition();
            }
        }
        else
        {
            _scoreTda.ResetList();
        }
      
    }
}
