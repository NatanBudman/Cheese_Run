using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarQuickSort : MonoBehaviour
{
    public GameObject levelPanel;
    public LevelInfo[] levels;
    // Start is called before the first frame update
    void Start()
    {
        QuickSort.quickSort(levels,0,levels.Length - 1);

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].gameObject.transform.SetParent(levelPanel.transform);
        }
        
    }
    
}
