using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            Invoke("DropPlatform", 0.1f);
            Destroy(gameObject, 1f);
        }
    }
    
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
