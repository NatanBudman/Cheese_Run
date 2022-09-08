using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManger : MonoBehaviour
{
    public Dictionary<string, int> ItemDictionary = new Dictionary<string, int>();
    
    [SerializeField] private GameObject[] Items;

    void Start()
    {
        GetPowersNames();
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
        Debug.Log("Una muzza");
    }
    private void CheddarPower()
    {
        Debug.Log("Un Cheddar");
    }
    private void GoudaPower()
    {
        Debug.Log("Un Gouda");
    }
    private void ParmesanoPower()
    {
        Debug.Log("Una Parmesano");
    }
}
