using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class CheeseManager : MonoBehaviour
{
    [SerializeField] private static CheeseManager instance;
    
    [SerializeField] private CheesePìla _cheesePìla;

    [SerializeField] private int TotalCheeseInGame;

    [SerializeField] private GameObject CheesePref;

    [SerializeField] private Transform CheeseSpawn;

    [SerializeField] private int MaxDistanceToInstanciateCheese;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    void Start()
    {
        _cheesePìla.Initialization(TotalCheeseInGame);

        Pooling.PreLoad(CheesePref,TotalCheeseInGame);

        StackCheeses();
    }

    void StackCheeses()
    {
        for (int i = 0; i < Pooling.Poolparent.childCount; i++)
        {
            var ChildsPool = Pooling.Poolparent.GetChild(i).gameObject;
            
            if (ChildsPool.GetComponent<Cheese>() != null) _cheesePìla.StackCheese(ChildsPool);

        }
    }

    void Update()
    {
        if (_cheesePìla.StackEmpty()) _cheesePìla.ResetPila();
        
        InstanciateCheese();
    }
    
    float InstanciateCheeseInGame;
    
    void InstanciateCheese()
    {
        InstanciateCheeseInGame += Time.deltaTime;
        var Instantiate = Random.Range(5, 10);
        if (InstanciateCheeseInGame >= Instantiate)
        {
            _cheesePìla.TopCheese().transform.position = 
                CheeseSpawn.transform.position + Random.insideUnitSphere * MaxDistanceToInstanciateCheese;

            _cheesePìla.TopCheese().gameObject.SetActive(true);
            
            _cheesePìla.UnstackCheese();
            
            InstanciateCheeseInGame = 0;
        }
    }
}
