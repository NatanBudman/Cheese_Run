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
            Invoke("InvensibilityDisable()", InvencibilityDuration);
        }

        if (BustSpeedDuration >= 1 && moveSpeed <= MaxSpeed) moveSpeed += 1 * Time.deltaTime;
        else if (BustSpeedDuration <= 0 && moveSpeed >= 5.1f) moveSpeed -= 1 * Time.deltaTime;

    }

    private void InvensibilityDisable() =>   IsInvencible = false;

    private GameObject ItemsCollision;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Cheese/Cheese"))
        {
            _points.GetCheesePoint(1);
            other.gameObject.SetActive(false);
        }
        
        ItemsCollision = other.gameObject;
        
        if (ItemsCollision != null)
        {
            ObjectDataScript itemID = ItemsCollision.GetComponent<ObjectDataScript>();

            if (Powers.ItemDictionary.ContainsValue(itemID.ID))
            {
                SaizedItem(ItemsCollision.tag);
            }
        }
       
    }


    private void OnTriggerExit(Collider other)
    {
        ItemsCollision = null;
    }

    void SaizedItem(string tag)
    {
        Powers.SelectedPower(tag);
    }
}
