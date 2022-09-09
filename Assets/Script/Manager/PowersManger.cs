using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManger : MonoBehaviour
{
    public Dictionary<string, int> ItemDictionary = new Dictionary<string, int>();

    [SerializeField] private Points _points;
    
    [SerializeField] private GameObject[] Items;

    [SerializeField] private PlayerController _playerController;
    
    

    void Start()
    {
        GetPowersNames();

        _playerController = FindObjectOfType<PlayerController>();

        _points = FindObjectOfType<Points>();
    }

    private void GetPowersNames()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            ItemDictionary.Add(Items[i].gameObject.name,Items[i].GetComponent<ObjectDataScript>().ID);
        }
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
        _playerController.IsInvencible = true;
        Debug.Log("Una muzza");
    }
    private void CheddarPower()
    {
        Debug.Log("Un Cheddar");
    }
    private void GoudaPower()
    {
        _points.MultiplicatorPoint = 2;
        Debug.Log("Un Gouda");
    }
    private void ParmesanoPower()
    {
        _playerController.BustSpeedDuration = 5;
    }
}
