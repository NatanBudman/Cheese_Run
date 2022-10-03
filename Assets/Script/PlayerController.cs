using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Components

        [SerializeField] private Points _points;
        public PowersManger Powers;
        public Rigidbody2D rb;
    public GameManager gm;
    #endregion

    #region Movement

      public float moveSpeed = 5;
      public float MaxSpeed = 10;

    #endregion

    #region PowersEvents

        public bool IsInvencible;
        [SerializeField] private int InvencibilityDuration; 
        public int BustSpeedDuration;

    #endregion


    public SpriteRenderer sprite;

    public bool hasgoudaDouble;
    
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

        if (life < 1) Death();

    }

    public void Death() => gameObject.SetActive(false);

    public int life = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") )
        {
            StartCoroutine(FlashRed());
            life--;
        }

        if (other.gameObject.CompareTag("Cheese/Cheese"))
        {
            if(hasgoudaDouble== true)
            {
                _points.GetCheesePoint(2);
                other.gameObject.SetActive(false);
            }
            else
            {
                _points.GetCheesePoint(1);
                other.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("Powers/Cheddar"))
        {
            gm.CurrentGammeTime += 30;
        }
        if (other.gameObject.CompareTag("Powers/Gouda"))
        {
            hasgoudaDouble = true;
            StartCoroutine(Gouda());
        }
        if (other.gameObject.CompareTag("Powers/Muzza"))
        {
            StartCoroutine(Muzza());
        }
        if (other.gameObject.CompareTag("Powers/Parmesano"))
        {
            moveSpeed = 10;
        }

    }

    public IEnumerator Muzza()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(10f);
        sprite.color = Color.blue;
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }

    public IEnumerator Gouda()
    {
        yield return new WaitForSeconds(5f);
        hasgoudaDouble = false;
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
