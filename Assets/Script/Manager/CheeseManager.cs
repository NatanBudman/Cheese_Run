using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;
using Random = UnityEngine.Random;

public class CheeseManager : MonoBehaviour
{
    private static CheeseManager instance;

    #region Cheese_Secction
    [Space]
    [Header("Cheese in GamePlay")]
    [Space]
       [SerializeField] private CheesePìla _cheesePìla;
    
        [SerializeField] private int TotalCheeseInGame;
    
        [SerializeField] private GameObject CheesePref;
    
        [SerializeField] private Transform CheeseSpawn;
    
        [SerializeField] private int MaxDistanceToInstanciateCheese;

    #endregion
 

        private void Awake()
        {
            if (CheeseManager.instance == null)
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
        // Inicializa la cola con los quesos totales que va a ver en el juego
        _cheesePìla.Initialization(TotalCheeseInGame);

      
        
        Pooling.PreLoad(CheesePref,TotalCheeseInGame);

        StackCheeses();

    }

    void StackCheeses()
    {
        for (int i = 0; i < Pooling.Poolparent.childCount; i++)
        {
            var ChildsPool = Pooling.Poolparent.GetChild(i).gameObject;
            // Agrega los quesos del pool a la cola
            if (ChildsPool.GetComponent<Cheese>() != null) _cheesePìla.StackCheese(ChildsPool);

        }
    }

    void Update()
    {
        if (GameObject.FindWithTag("Cheese/CheeseSpawn") != null )
        {
            // Spawn Cheese
            CheeseSpawn.transform.position = GameObject.FindWithTag("Cheese/CheeseSpawn").transform.position;
            // Resetea la cola
            if (_cheesePìla.StackEmpty()) _cheesePìla.ResetPila();
             InstantiateCheese();
        }
    }
    
    float InstanciateCheeseInGame;
    
    void InstantiateCheese()
    {
        InstanciateCheeseInGame += Time.deltaTime;
        
        var Instantiate = Random.Range(5, 10);
        if (InstanciateCheeseInGame >= Instantiate)
        {
            // Setea la posicion del ultimo queso
            _cheesePìla.TopCheese().transform.position = 
                CheeseSpawn.transform.position + Random.insideUnitSphere * MaxDistanceToInstanciateCheese;

            _cheesePìla.TopCheese().gameObject.SetActive(true);
            // Pasa al siguiente queso
            _cheesePìla.UnstackCheese();
            
            InstanciateCheeseInGame = 0;
        }
    }
}
