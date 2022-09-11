using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D colider;
    public Rigidbody2D rb;

    private float width;
    private float scrollSpeed = -4f;

    // Start is called before the first frame update
    void Start()
    {
        colider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = colider.size.x;
        colider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
        ResetObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
            ResetObstacle();
        }
    }

    void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(0, Random.Range(-3, 3), 0);
    }
}
