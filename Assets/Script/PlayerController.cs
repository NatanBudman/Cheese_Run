using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PowersManger Powers;
    
    public Rigidbody2D rb;
    public float moveSpeed = 5;

    public bool hasMuzza;
    public bool hasCheddar;
    public bool hasGouda;
    public bool hasParm;



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

        if (this.gameObject.activeSelf == false)
        {
            Invoke("ResetPlayer()",3);
        }
    }

    private void ResetPlayer()
    {
        this.gameObject.SetActive(true);
    }

    private GameObject ItemsCollision;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            this.gameObject.SetActive(false);
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
