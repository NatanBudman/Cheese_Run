using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D colider;
    public Rigidbody2D rb;
    private Camera mainCamera;
    public Transform ResetPos;

    private float width;
    [SerializeField]private float ImgDistance = 25;
    public float scrollSpeed = -4f;

    // Start is called before the first frame update
    void Start()
    {
        colider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        width = mainCamera.transform.position.x - ImgDistance;
        colider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
        ResetObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < width)
        {
            
            transform.position = ResetPos.position;
            ResetObstacle();
        }
    }

    void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(0, Random.Range(-3, 3), 0);
    }

  
}
