using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Animations : MonoBehaviour
{

    public Animator Zom_anim;
    // Start is called before the first frame update
    void Start()
    {
        Zom_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ENEMY_MOVEMENT.enemy_instance.isPatroling && ENEMY_MOVEMENT.enemy_instance.currentTransformIndex >= 0)
        {
            Zom_anim.SetBool("isIdle", false);
        }


        if (ENEMY_MOVEMENT.enemy_instance.dist <= ENEMY_MOVEMENT.enemy_instance.look_radius && ENEMY_MOVEMENT.enemy_instance.isChasing )
        {
           Zom_anim.SetBool("isRunning", true);
        }
        else if (ENEMY_MOVEMENT.enemy_instance.dist >= ENEMY_MOVEMENT.enemy_instance.look_radius && ENEMY_MOVEMENT.enemy_instance.isChasing)
        {
            Zom_anim.SetBool("isIdle", false);
        }

        //if (ENEMY_MOVEMENT.enemy_instance.isAttacking && ENEMY_MOVEMENT.enemy_instance.dist <= ENEMY_MOVEMENT.enemy_instance.attack_radius)
        //{
        //    Zom_anim.SetBool("isAttacking", true);
        //}
        //else if (ENEMY_MOVEMENT.enemy_instance.isAttacking && ENEMY_MOVEMENT.enemy_instance.dist >= ENEMY_MOVEMENT.enemy_instance.attack_radius)
        //{
        //    Zom_anim.SetBool("isAttacking", false);
        //}



    }
}
