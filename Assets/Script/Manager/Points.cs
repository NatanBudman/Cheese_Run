using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public int MultiplicatorPoint = 1;
    
    public int CheeseNeed;

    [SerializeField]private int _cheeseRecoleted;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MultiplicatorPoint > 1) MultiplicatorDisable();

        if (_cheeseRecoleted > 0)
        {
             _gameManager.CheeseRecolected = SetPoints();
             Debug.Log(_gameManager.CheeseRecolected);
        }
    }

    void MultiplicatorDisable() => MultiplicatorPoint = 1;
    
    public int GetCheesePoint(int cheesePoints)
    {
        _cheeseRecoleted = cheesePoints;
        return  _cheeseRecoleted;
    }

    public int SetPoints()
    {
        _gameManager.CheeseRecolected += _cheeseRecoleted * MultiplicatorPoint;
        _cheeseRecoleted = 0;
        return _gameManager.CheeseRecolected;
    }
}
