using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreList 
{
    public void Initialization(int AmountPila);

    public void StackCheese(PlayerData playerData,int Stars);

    public void UnstackCheese();

    public string TopCheese();

    public bool StackEmpty();

    public void ResetPila();
}
