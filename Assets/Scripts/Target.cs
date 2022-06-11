using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;
    public bool isDead;

    
    public void take_damage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
    
            isDead = true;
            Die();
               
        }
        else
        {
            isDead = false;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
   
}
