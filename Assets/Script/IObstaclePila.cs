using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public interface IObstaclePila
{
    public void Initialization(int AmountPila);

    public void StackObstacle(GameObject Obstacle);

    public void UnstackObstacle();

    public GameObject TopObstacle();

    public bool StackEmpty();

    public void ResetPila();
}
