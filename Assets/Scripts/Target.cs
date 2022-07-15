using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 100f;
    public bool isDead1 =false;
    public bool isDead2 =false;
    public bool isDead3 =false;
    public bool isDead4 =false;
    public bool isDead5 =false;
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
    public void take_damage1(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {   
            isDead1 = true;          
            ENEMY_MOVEMENT.enemy_instance.zombie.GetComponent<ENEMY_MOVEMENT>().enabled = false;

            ENEMY_MOVEMENT.enemy_instance.anime.Play("ZOMBIE_DIE1");

            if (isDead1)
            {
                Invoke("Die", 10);
            }
        }
               
    }

    public void take_damage2(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isDead2 = true;
            ENEMY_MOVEMENT2.enemy_instance.zombie2.GetComponent<ENEMY_MOVEMENT2>().enabled = false;
            ENEMY_MOVEMENT2.enemy_instance.anime2.Play("ZOMBIE_DIE2");
            if (isDead2)
            {
                Invoke("Die", 10);
            }
        }
    }

    public void take_damage3(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isDead3 = true;
            ENEMY_MOVEMENT3.enemy_instance.zombie3.GetComponent<ENEMY_MOVEMENT3>().enabled = false;
            ENEMY_MOVEMENT3.enemy_instance.anime3.Play("ZOMBIE_DIE3");
            if (isDead3)
            {
                Invoke("Die", 10);
            }
        }
    }

    public void take_damage4(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isDead4 = true;
            ENEMY_MOVEMENT4.enemy_instance.zombie4.GetComponent<ENEMY_MOVEMENT4>().enabled = false;
            ENEMY_MOVEMENT4.enemy_instance.anime4.Play("ZOMBIE_DIE4");
            if (isDead4)
            {
                Invoke("Die",3);
            }
        }
    }

    public void take_damage5(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isDead5 = true;
            ENEMY_MOVEMENT5.enemy_instance.zombie5.GetComponent<ENEMY_MOVEMENT5>().enabled = false;
            ENEMY_MOVEMENT5.enemy_instance.anime5.Play("ZOMBIE_DIE5");
            if (isDead5)
            {
                Invoke("Die", 10);
            }
        }
    }

    public void Die()
    {
       /* isDead1 = false*/;
        gameObject.SetActive(false);
        Destroy(gameObject);

    }

}
