using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersMovement : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            transform.position = new Vector2(transform.position.x - Speed, transform.position.y);
        }
    }
}
