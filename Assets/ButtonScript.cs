using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject me;
    public GameObject popUp;

    public void Click()
    {
        me.SetActive(false);
        popUp.SetActive(true);
    }
}
