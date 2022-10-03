using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreList 
{
    public void Initialization(int AmountPila);

    public void StackPlayers(PlayerData playerData);

    public void UnstackPlayer();

    public PlayerData TopPlayer();

    public bool StackEmpty();

    public void ResetList();
}
