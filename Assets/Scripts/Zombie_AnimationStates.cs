using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AnimationStates : MonoBehaviour
{
    public string currentstate;
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        playanimstate("ZOMBIE_WALKING");
    }

    // Update is called once per frame
    void Update()
    {
        updateanimation();
    }
    public void updateanimation()
    {
        //if (ENEMY_MOVEMENT.enemy_instance.isPatroling && ENEMY_MOVEMENT.enemy_instance.currentTransformIndex >= 0)
        //{
        //    playanimstate("ZOMBIE_WALKING");
        //}

        if (ENEMY_MOVEMENT.enemy_instance.dist <= ENEMY_MOVEMENT.enemy_instance.look_radius && ENEMY_MOVEMENT.enemy_instance.isChasing)
        {
            playanimstate("ZOMBIE_RUNNING");
        }
        else if (ENEMY_MOVEMENT.enemy_instance.dist >= ENEMY_MOVEMENT.enemy_instance.look_radius && ENEMY_MOVEMENT.enemy_instance.isChasing == false)
        {
            playanimstate("ZOMBIE_WALKING");
        }

    }
   private void playanimstate(string state)
    {
      if (currentstate == state)
          return;

      anime.Play(state);
      currentstate = state;
    }
}
