using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTDA : MonoBehaviour,IScoreList
{
    private PlayerData[] _playerData;
    private int index;

    public void Initialization(int AmountPila)
    {
        _playerData = new PlayerData[AmountPila];
        index = 0;
    }

    public void StackPlayers(PlayerData playerData)
    {
        int j;
        for (j = index; j > 0 && _playerData[j - 1].AllCollectionPlayerStars >= playerData.AllCollectionPlayerStars; j--)
        {
            _playerData[j] = _playerData[j - 1];
        }
        _playerData[j] = playerData;

        index++;
    }

    public void UnstackPlayer() =>         index--;


    public PlayerData TopPlayer()
    {
        return _playerData[index - 1];
    }

    public void UnstackPosition()
    {
        _playerData[index - 1] = null;
         index--;
    }

    public bool StackEmpty()
    {
        return (index >= 5);
    }

    public void ResetList()
    {
        index = 0;
    }
}
