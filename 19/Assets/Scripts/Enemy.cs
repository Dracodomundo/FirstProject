using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currenthealth;
    void Start()
    {
        currenthealth = maxHealth;
    }
 
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;

        animator.SetTrigger("Hit");

        if(currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("IsDead",true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
       
        
    }
}
