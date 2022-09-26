using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTDA : MonoBehaviour,IScoreList
{
    private int[] Stars;
    private PlayerData[] _playerData;
    private int index;

    public void Initialization(int AmountPila)
    {
        Stars = new int[AmountPila];
        _playerData = new PlayerData[AmountPila];
    }

    public void StackCheese(PlayerData playerData, int Stars)
    {
        throw new System.NotImplementedException();
    }

    public void UnstackCheese()
    {
        throw new System.NotImplementedException();
    }

    public string TopCheese()
    {
        throw new System.NotImplementedException();
    }

    public bool StackEmpty()
    {
        throw new System.NotImplementedException();
    }

    public void ResetPila()
    {
        throw new System.NotImplementedException();
    }
}
