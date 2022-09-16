using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowersQueue
{
    void Initialization(int amount);
    
    void StackQueuePowers(GameObject powers, string TypeObject);
    
    void UnstackQueuePower();
    
    bool EmptyQueue();
    
    GameObject FirstPower();
}
