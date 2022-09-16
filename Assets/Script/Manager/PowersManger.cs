using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        #region InicializeQueuePower

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

    string PowersNeedInstanciatePowersInMap()
    {
        
        if (_gameManager.GameTime <= 25 && _gameManager.CheeseRecolected >= _points.CheeseNeed * 25 / 100 )
        {
            return TDA_keyPowerCheedar;
        }

        if (_gameManager.GameTime > 25 && _gameManager.CheeseRecolected <= _points.CheeseNeed * 25 / 100 )
        {
            return TDA_keyPowerGouda;
        }
        if (_gameManager.GameTime > 45 && _gameManager.CheeseRecolected > _points.CheeseNeed * 25 / 100 )
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
