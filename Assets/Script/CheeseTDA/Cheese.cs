using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public float Speed;

    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float _cameraWidth;

    [SerializeField] private bool IsCheeseCollecteble;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = FindObjectOfType<Camera>();
        
        _cameraWidth = PlayerCamera.transform.position.x - 12;
        if (IsCheeseCollecteble)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _cameraWidth)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime,transform.position.y);
        }
    }




}
