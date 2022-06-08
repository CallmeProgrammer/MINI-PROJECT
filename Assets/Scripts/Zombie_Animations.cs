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
        if(ENEMY_MOVEMENT.enemy_instance.isPatroling)
        {
            Zom_anim.SetBool("isIdle", false);
        }
        else if(ENEMY_MOVEMENT.enemy_instance.isChasing)
        {
            Zom_anim.SetBool("isWalking", false);
        }
        else if(ENEMY_MOVEMENT.enemy_instance.isAttacking)
        {
            Zom_anim.SetBool("isAttacking", false);
        }
        else if(ENEMY_MOVEMENT.enemy_instance.isAttacking == false)
        {
            Zom_anim.SetBool("isRunning", true);
        }
    }
}
