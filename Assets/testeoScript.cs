using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class testeoScript : MonoBehaviour
{
    public int amount;

    public Transform pos;

    public GameObject pref;
    
    // Start is called before the first frame update
    
    void Start()
    {
        // Pre cargar assets
        Pooling.PreLoad(pref,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (amount > 0)
        { 
            // Ejemplo del Instanciador del Pooling
            Pooling.PoolInstance(pref, pos, quaternion.identity, pos.transform);
            amount--;
        }

        if (amount < 0)
        {
            // Ejemplo del Removedor del Pooling
            Pooling.RemovedObject(pref);
            amount++;
        }
    }
}
