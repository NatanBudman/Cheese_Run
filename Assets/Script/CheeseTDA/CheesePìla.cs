using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheesePìla : MonoBehaviour,ICheesePila
{
   [SerializeField] private  GameObject[] _Cheeses;

    private int _index;

    public void Initialization(int AmountPila) =>  _Cheeses = new GameObject[AmountPila];

    public void StackCheese(GameObject Cheese)
    {
        _Cheeses[_index] = Cheese;
        _index++;
      
    }

    public void UnstackCheese() =>  _index--;


    public GameObject TopCheese() => _Cheeses[_index - 1].gameObject;


    public bool StackEmpty() =>      _index == 0;

    public void ResetPila() =>       _index = _Cheeses.Length;

}
