using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Points _points;
    public PowersManger Powers;
    
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public float MaxSpeed = 10;
    
    public bool IsInvencible;
    [SerializeField] private int InvencibilityDuration; 
    public int BustSpeedDuration;

    public SpriteRenderer sprite;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        _points = FindObjectOfType<Points>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, moveDirection * moveSpeed);

        if (this.gameObject.activeSelf == false)
        {
            Invoke("ResetPlayer()",3);
        }

        if (IsInvencible)
        {
            Debug.Log("es invencible");
        }

        if (BustSpeedDuration >= 1 && moveSpeed <= MaxSpeed) moveSpeed += 1 * Time.deltaTime;
        else if (BustSpeedDuration <= 0 && moveSpeed >= 5.1f) moveSpeed -= 1 * Time.deltaTime;

        if (life < 1) gameObject.SetActive(false);
        
    }

    private int life = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") )
        {
            StartCoroutine(FlashRed());
            life--;
        }

        if (other.gameObject.CompareTag("Cheese/Cheese"))
        {
            _points.GetCheesePoint(1);
            other.gameObject.SetActive(false);
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
