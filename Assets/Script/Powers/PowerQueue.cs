using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerQueue : MonoBehaviour,IPowersQueue
{
    GameObject[] Powers;
    private string[] TypeObjectNeed; // Tipo de poder para ajustar a la necesidad de la situacion
    int index; 
    
    public void Initialization(int amount)
    {
        Powers = new GameObject[amount];
        TypeObjectNeed = new string[amount];
        index = 0;
    }

    public void StackQueuePowers(GameObject powers, string TypePower)
    {
        for (int i = index - 1; i >= 0; i--)
        {
            Powers[i + 1] = Powers[i];
            TypeObjectNeed[i + 1] = TypeObjectNeed[i];
        }
        Powers[0] = powers;
        TypeObjectNeed[0] = TypePower;
        index++;
    }

    public void UnstackQueuePower()
    {
        index--;
    }

    public GameObject PowerNeed(string PowerTypeNeed)
    {
        GameObject PowerNeed = null;
        
        for (int i = 0; i < TypeObjectNeed.Length - 1; i++)
        {
            if (TypeObjectNeed[i] == PowerTypeNeed)
            {
                PowerNeed = Powers[i].gameObject;
            }
        }

        return PowerNeed;
    }

    public bool EmptyQueue() => index == 0;


    public GameObject FirstPower() => Powers[index - 1];

    public void ResetQueue() => index = 0;

}
