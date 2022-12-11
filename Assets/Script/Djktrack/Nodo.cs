using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    public int info;
    public Nodo sig;

    private AplicarDijskra _aplicarDijskra;

    private void Start()
    {
        _aplicarDijskra = FindObjectOfType<AplicarDijskra>();
    }

    private void OnMouseUp()
    {
        _aplicarDijskra.FindNewObjetive(info);
    }
}
