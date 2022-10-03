using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowersManger : MonoBehaviour
{
    public Dictionary<GameObject, string> PowerKeyDictionary = new Dictionary<GameObject, string>();

    [SerializeField] private Points _points;
    
    [SerializeField] private PlayerController _playerController;
    
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private GameObject[] _powers;

    public GameObject PowerPickUp;

    [SerializeField]
    private Transform PowerSpawn;

    #region Powers_Secction
     [Space]
     [Header("Powers")]
     
     [Space]
     [SerializeField] private PowerQueue _PowerQueue;
     [Space]
     
     [SerializeField] private int TotalPowers;
     [Range(5,25)]
     [SerializeField] private int InstantiatePowerCooldown;
     [Range(2,6)]
     [SerializeField] private int RangeInstantiatePower;
     private float CurrentInstantiatePower;
     
     [Space]
     [Header("PowersKeys")]
     [Space]
     
     [SerializeField] private string TDA_keyPowerParmersano;
     [SerializeField] private string TDA_keyPowerCheedar;
     [SerializeField] private string TDA_keyPowerMuzza;
     [SerializeField] private string TDA_keyPowerGouda;
     
     [Space]
     [Header("PowersObjects")]
     [Space]
     
     [SerializeField] private GameObject PowerCheedar;
     [SerializeField] private GameObject PowerParmesano;
     [SerializeField] private GameObject PowerGouda;
     [SerializeField] private GameObject PowerMuzza;

    #endregion

   

    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        
        _points = FindObjectOfType<Points>();

        #region Inicialize_Queue_Power

        _PowerQueue.Initialization(TotalPowers);
        
        _PowerQueue.StackQueuePowers(PowerCheedar,TDA_keyPowerCheedar);
        _PowerQueue.StackQueuePowers(PowerMuzza,TDA_keyPowerMuzza);
        _PowerQueue.StackQueuePowers(PowerGouda,TDA_keyPowerGouda);
        _PowerQueue.StackQueuePowers(PowerParmesano,TDA_keyPowerParmersano);

        #endregion
    }

    private void Update()
    {
        if(_PowerQueue.EmptyQueue()) _PowerQueue.ResetQueue();

        if (!_gameManager.isFinishGame)
        {
            InstantiatePowers();
        }
        
    }

    #region Method_Powers_Activation

     public void SelectedPower(string PowerTag) 
        {
            if (PowerTag == "Powers/Cheddar")
            {
                CheddarPower();
            }
            if (PowerTag == "Powers/Muzza")
            {
                MuzzaPower();
            }
            if (PowerTag == "Powers/Gouda")
            {
                GoudaPower();
            }
            if (PowerTag == "Powers/Parmesano")
            {
                ParmesanoPower();
            }
        }
    
        private void MuzzaPower()
        {
            // invencible
        }
        private void CheddarPower()
        {
        }
        private void GoudaPower()
        {
            _points.MultiplicatorPoint = 2;
        }
        
        // Queue Powers interface \\
        private void ParmesanoPower()
        {
            
        }

    #endregion

    #region Power_Instanciate_Conditions

    private void InstantiatePowers()
    {
        CurrentInstantiatePower += Time.deltaTime;
        
        var RamdomInt = Random.Range(0, 5);
        
        if (CurrentInstantiatePower >= InstantiatePowerCooldown)
        {
            // Select Orden list Power (QUEUE)
            if (RamdomInt == 4 ||RamdomInt == 5 || RamdomInt == 2)
            {
                 _PowerQueue.FirstPower().transform.position = PowerSpawn.transform.position + Random.insideUnitSphere * RangeInstantiatePower;
                                _PowerQueue.FirstPower().gameObject.SetActive(true);
                                _PowerQueue.UnstackQueuePower();
                                Debug.Log("4-5");
            }
            // Select Player Power Need 
            if (RamdomInt == 1)
            {
                string j = PowersNeedInstanciatePowersInMap();
                 
                _PowerQueue.PowerNeed(j).transform.position = PowerSpawn.transform.position + Random.insideUnitSphere * RangeInstantiatePower;;
                _PowerQueue.PowerNeed(j).SetActive(true);
                Debug.Log("1-2");
 
            }
 
            
            CurrentInstantiatePower = 0;
        }
      
    }

    private string PowersNeedInstanciatePowersInMap()
    {
        // System Power Need 
        if (_gameManager.GameTime <= 25 && _gameManager.CheeseRecolected >= _points.CheeseNeed * 25 / 100 && _playerController.life > 1 )
        {
            return TDA_keyPowerCheedar;
        }

        if (_gameManager.GameTime > 25 && _gameManager.CheeseRecolected <= _points.CheeseNeed * 25 / 100 && _playerController.life > 1)
        {
            return TDA_keyPowerGouda;
        }
        if (_gameManager.GameTime > 45 && _gameManager.CheeseRecolected > _points.CheeseNeed * 25 / 100 && _playerController.life > 1 )
        {
            return TDA_keyPowerParmersano;
        }
        if (_playerController.life == 1)
        {
            return TDA_keyPowerMuzza;
        }


        return null;
    }

    #endregion
   
}
