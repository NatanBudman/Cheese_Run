using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManger : MonoBehaviour
{
    public Dictionary<GameObject, string> PowerKeyDictionary = new Dictionary<GameObject, string>();

    [SerializeField] private Points _points;
    
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private GameObject[] _powers;

    public GameObject PowerPickUp;

    void Start()
    {
        GetPowersNames();

        _playerController = FindObjectOfType<PlayerController>();
        
        _points = FindObjectOfType<Points>();
        
   
    }

    private void GetPowersNames()
    {
      
    }

    private void Update()
    {
    }

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

   
}
