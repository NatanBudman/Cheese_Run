using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LevelData : MonoBehaviour
{
    public LevelInfo[] levels;
    public int[] levelStars;

    private void Start()
    {
        levelStars = new int[levels.Length];
      
    }

    private void Update()
    {
        if (Menu.isChangeAccount)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levelStars[i] = levels[i].LevelStars;
                if (i == levels.Length - 1)
                {
                    Menu.isChangeAccount = false;
                    break;
                }
            }
        
        }
    }
}
