using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5;

    public bool hasMuzza;
    public bool hasCheddar;
    public bool hasGouda;
    public bool hasParm;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, moveDirection * moveSpeed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;

    }

    public IEnumerator Jump()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
}
