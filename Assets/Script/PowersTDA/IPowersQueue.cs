using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowersQueue
{
    void Initialization();
    
    void StackQueuePowers(Powers powers);
    
    void UnstackQueuePower();
    
    bool EmptyQueue();
    
    int TopPower();
}
