using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{

    public float health = 100f;
    public bool isDead1 =false;
    public bool isDead2 =false;
    public bool isDead3 =false;
    public bool isDead4 =false;
    public bool isDead5 =false;
    public static Target target_instance;
    public TextMeshProUGUI zombi_kill_count;
    

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
        //if (GetComponent<Gun>().isZombie_hitting)
        //{
        //    GetComponent<ENEMY_MOVEMENT>().anime.Play("ZOMBIE_HIT1");
        //}
        //else
       if (health <= 0f)
        {   
            isDead1 = true;
            //zombi_kill_count.text += 1;
            GetComponent<ENEMY_MOVEMENT>().enabled = false;
           GetComponent<ENEMY_MOVEMENT>().anime.Play("ZOMBIE_DIE1");
            if (isDead1)
            {
                zombi_kill_count.text += 1; 
                Invoke("Die", 5);
            }
        }
               
    }

    public void take_damage2(float amount)
    {
        health -= amount;
        //if (GetComponent<Gun>().isZombie_hitting)
        //{
        //    GetComponent<ENEMY_MOVEMENT2>().anime2.Play("ZOMBIE_HIT2");
        //}

        if (health <= 0f)
        {
            isDead2 = true;
            GetComponent<ENEMY_MOVEMENT2>().enabled = false;
            GetComponent<ENEMY_MOVEMENT2>().anime2.Play("ZOMBIE_DIE2");
            if (isDead2)
            {
                Invoke("Die", 5);
            }
        }
    }

    public void take_damage3(float amount)
    {
        health -= amount;
        //if (GetComponent<Gun>().isZombie_hitting)
        //{
        //    GetComponent<ENEMY_MOVEMENT3>().anime3.Play("ZOMBIE_HIT3");
        //}

        if (health <= 0f)
        {
            isDead3 = true;
            GetComponent<ENEMY_MOVEMENT3>().enabled = false;
            GetComponent<ENEMY_MOVEMENT3>().anime3.Play("ZOMBIE_DIE3");
          
            if (isDead3)
            {
                Invoke("Die", 5);
            }
        }
    }

    public void take_damage4(float amount)
    {
        health -= amount;
        //if (GetComponent<Gun>().isZombie_hitting)
        //{
        //    GetComponent<ENEMY_MOVEMENT4>().anime4.Play("ZOMBIE_HIT4");
        //}

        if (health <= 0f)
        {
            isDead4 = true;
            GetComponent<ENEMY_MOVEMENT4>().enabled = false;
            GetComponent<ENEMY_MOVEMENT4>().anime4.Play("ZOMBIE_DIE4");
            if (isDead4)
            {
                Invoke("Die", 5);
            }
        }
    }

    public void take_damage5(float amount)
    {
        health -= amount;
        //if (GetComponent<Gun>().isZombie_hitting)
        //{
        //    GetComponent<ENEMY_MOVEMENT5>().anime5.Play("ZOMBIE_HIT5");
        //}

        if (health <= 0f)
        {
            isDead5 = true;
            ENEMY_MOVEMENT5.enemy_instance.zombie5.GetComponent<ENEMY_MOVEMENT5>().enabled = false;
            GetComponent<ENEMY_MOVEMENT5>().anime5.Play("ZOMBIE_DIE5");
            if (isDead5)
            {
                Invoke("Die", 5);
            }
        }
    }

    public void Die()
    {
       /* isDead1 = false*/;
        gameObject.SetActive(false);
        //Destroy(gameObject);

    }

}
