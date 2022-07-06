using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;
    public bool isDead = false;
    public static Target target_instance;
    public int zom_num;
    

    public void Awake()
    {
        if (target_instance != null)
        {
            return;
        }
        target_instance = this;
    }
    public void take_damage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
    
            isDead = true;
            Spawners.Spawners_instance.Zombie_Amount--;
            Die();
        }
        else
        {
            isDead = false;
        }
    }
    void Die()
    {
        gameObject.SetActive(false);

    }

}
