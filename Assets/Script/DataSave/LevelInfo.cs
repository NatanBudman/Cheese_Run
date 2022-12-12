using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public GameObject[] Stars = new GameObject[3];
    public int StarsWin;
    public int Starshave;
    public int Level;
    private readonly int _maxStarsWin = 3;

    private void Update()
    {
        if (Starshave != StarsWin && Starshave < _maxStarsWin)
        {
            while (Starshave <= StarsWin)
            {
                Stars[Starshave].SetActive(true);
                Starshave++;
            }
        }
    }
}
