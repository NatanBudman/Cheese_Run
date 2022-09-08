using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public interface ICheesePila
{

    public void Initialization(int AmountPila);

    public void StackCheese(GameObject Cheese);

    public void UnstackCheese();

    public GameObject TopCheese();

    public bool StackEmpty();

    public void ResetPila();

}
