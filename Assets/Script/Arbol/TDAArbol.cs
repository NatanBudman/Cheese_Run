using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TDAArbol : MonoBehaviour
{
    public ArbolNode root;
    //public ArbolNode nodePrefab;
    private ArbolNode currentNode;
    //public InputField inputBox;
    public ArbolNode[] cheesePrefabs;

    private void Update()
    {

    }

    public void AddNode(int valueToAdd)
    {
        int randomIndex = Random.Range(0, cheesePrefabs.Length);
        ArbolNode randomCheese = cheesePrefabs[randomIndex];
        valueToAdd = randomCheese.value;
        ArbolNode newNode = Instantiate(randomCheese);
        newNode.transform.SetParent(GameObject.Find("Canvas").transform);
        newNode.value = valueToAdd;

        bool nodeAdded = false;
        if (!root) {
            root = newNode;
            newNode.isRoot = true;
            
        } 
        else 
        {
            currentNode = root;
            while (!nodeAdded) 
            {
                if(newNode.value > currentNode.value) 
                {
                    if (currentNode.highNode) 
                    {
                        currentNode = currentNode.highNode;
                    } 
                    else
                    {
                        currentNode.highNode = newNode;
                        newNode.parentNode = currentNode;
                        nodeAdded = true;
                    }
                } 
                else if (newNode.value < currentNode.value)
                {
                    if (currentNode.lowNode) 
                    {
                        currentNode = currentNode.lowNode;
                    }
                    else
                    {
                        currentNode.lowNode = newNode;
                        newNode.parentNode = currentNode;
                        nodeAdded = true;
                    }
                } 
                else 
                {
                    nodeAdded = true;
                    Destroy(newNode.gameObject);
                }
            }
        }
    }

    //public ArbolNode FindNode(int valueToFind)
    //{
    //    valueToFind = int.Parse(random);
    //    if (root) 
    //    {
    //        currentNode = root;
    //        if (valueToFind == root.value)
    //        {
    //            return root;
    //        }
    //        while (currentNode.value != valueToFind) 
    //        {
    //            if(valueToFind < currentNode.value) 
    //            {
    //                if (currentNode.lowNode) 
    //                {
    //                    currentNode = currentNode.lowNode;
    //                }
    //                else 
    //                {
    //                    break;
    //                }
    //            }
    //        }
    //        if (currentNode.value == valueToFind)
    //        {
    //            return currentNode;
    //        } 
    //        else 
    //        {
    //            return null;
    //        }
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}
}
