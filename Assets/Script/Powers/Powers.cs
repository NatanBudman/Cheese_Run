using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public PlayerController _Player;
    public PowersManger powersManger;

    private bool isPowerIsExecuted;

    private void Start()
    {
        _Player = FindObjectOfType<PlayerController>();
        powersManger = GetComponent<PowersManger>();
        DontDestroyOnLoad(gameObject);
        
    }

    public GameObject PowerCollisionWithPlayer()
    {
        return this.gameObject;
    }
 
    public bool ExecutePower()
    {
        return isPowerIsExecuted;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PJ"))
        {
            Debug.Log("entre");
            isPowerIsExecuted = true;
            powersManger.PowerPickUp = other.gameObject;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPowerIsExecuted = false;
    }
  
}



