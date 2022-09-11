using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public PlayerController _Player;
    public PowersManger powersManger;

    private bool isPowerIsExecuted;

    // Power Class //
    private MuzzarellaPower _muzzarellaPower;
    private void Start()
    {
        _Player = FindObjectOfType<PlayerController>();
        powersManger = GetComponent<PowersManger>();
        DontDestroyOnLoad(gameObject);
        
        // Inicialization Powers Class //
        _muzzarellaPower = new MuzzarellaPower(5,2,"Muzza");
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

// Powers Class //
public class Power
{
    private Collider _collider;
    private readonly string _keyPower;

    public Power(Collider collider,string keyPower)
    {
        _collider = collider;
        _keyPower = keyPower;
    }

}

public class MuzzarellaPower
{
    private readonly int BustSpeed;
    private readonly int durationBust;
    private readonly string keyPower;

    public MuzzarellaPower(int BustSpeed,int DurationBust, string KeyPower)
    {
        this.BustSpeed = BustSpeed;
        this.durationBust = DurationBust;
        keyPower = KeyPower;
    }

    public int SpeedBust()
    {
        return BustSpeed;
    }

    public int DurationBustSpeed()
    {
        return durationBust;
    }

    public bool HasInvecibility() => true;
    
    public bool HasntInvecibility() => false;
}
