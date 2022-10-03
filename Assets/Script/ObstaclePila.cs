using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePila : MonoBehaviour, IObstaclePila
{
    [SerializeField] private GameObject[] _Obstacles;

    private int _index;

    public void Initialization(int AmountPila) => _Obstacles = new GameObject[AmountPila];

    public void StackObstacle(GameObject Obstacles)
    {
        _Obstacles[_index] = Obstacles;
        _index++;
    }

    public void UnstackObstacle() => _index--;


    public GameObject TopObstacle() => _Obstacles[_index - 1].gameObject;


    public bool StackEmpty() => _index == 0;

    public void ResetPila() => _index = _Obstacles.Length - 1;
}
