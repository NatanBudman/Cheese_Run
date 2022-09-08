using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling instance;
    
    public static List<GameObject> pool;

    public static Transform Poolparent;

    private static int IDs = 0;
    private void Awake()
    {
        if (Pooling.instance == null)
        {
            Pooling.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        pool = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs"));
        
        Poolparent = this.gameObject.transform;

    }

    void Start()
    {
       
        GetID();
    }

    static void DisableParentChilds()
    {
        for (int i = 0; i < Poolparent.childCount; i++)
        {
            var ChildObject = Poolparent.transform.GetChild(i).gameObject;
            ChildObject.SetActive(false);
        }
    }
    void GetID()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if( pool[i].GetComponent<ObjectDataScript>() == null)
            {
                pool[i].AddComponent<ObjectDataScript>().ID = IDs;
            }
            IDs++;
        }
    }

    public static void PoolInstance(GameObject gameObject, Transform transform, Quaternion quaternion, Transform parent)
    {
        bool isDontHaveObject = Poolparent.transform.childCount == 0;
   
        for (int i = 0; i < Poolparent.transform.childCount; i++)
        {
            var ChildObject = Poolparent.transform.GetChild(i).gameObject;
            
            if (gameObject.GetComponent<ObjectDataScript>().ID == ChildObject.GetComponent<ObjectDataScript>().ID)
            {
                Debug.Log($"Hay Objecto {ChildObject.name}");
                SetPosition(ChildObject,transform,quaternion,parent);
                break;
            }
            
            if (i == Poolparent.transform.childCount)
            {
                isDontHaveObject = true;
                Debug.Log($"No se encontro el Objecto {ChildObject.name}");
                break;
            }
        }

        if (isDontHaveObject)
        {                
            Debug.Log($"No se encontro el Objecto : Instanciando {gameObject.name}");

            Instantiate(gameObject, transform.position, Unity.Mathematics.quaternion.identity, parent);
        }
        
        gameObject = null;
    }

    private static void SetPosition(GameObject gameObject, Transform transform, Quaternion quaternion, Transform parent)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = transform.position;
        gameObject.transform.rotation = quaternion;
        gameObject.transform.SetParent(parent);
    }

    public static void RemovedObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(Poolparent);
    }

    public static void PreLoad(GameObject PreLoadObject,int GameObejctAmount)
    {
        if (pool.Count > 0)
        {
            for (int i = 0; i < GameObejctAmount; i++)
            {
                Instantiate(PreLoadObject, Poolparent.transform.position, quaternion.identity, Poolparent);
                
                if (i == GameObejctAmount)
                {
                    break;
                }
            }

            DisableParentChilds();
        }
    }

}
