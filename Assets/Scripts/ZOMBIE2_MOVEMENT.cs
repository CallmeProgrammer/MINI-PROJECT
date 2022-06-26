using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZOMBIE2_MOVEMENT : MonoBehaviour
{
    public NavMeshAgent Zombie2;
    public Transform Player_Position;
    public int currentPreyIndex;
    public Animator Play_anim;
    public float dist;
    public Transform[] Prey_points;
    public bool isPreying = false;
    public bool ishunting = false;
    
    public bool isAttacking;
    public GameObject Player;

    public float lookradius = 30f;

    public string currentstate;
    // Start is called before the first frame update
    void Start()
    {
        Zombie2.GetComponent<NavMeshAgent>();
        Play_anim.GetComponent<Animator>();
        zombie_Hunt();
    }

    // Update is called once per frame
    void Update()
    {
        update_animation();
        dist = Vector3.Distance(Player_Position.position, transform.position);
        if (Player.GetComponent<Player_New>().isRunning || Gun.Gun_instance.isShooting == true)
        {
            ishunting = true;
            attack_player();

        }
        else if(dist <= lookradius)
        {          
            attack_player();
        }

      
    }
    public void attack_player()
    {

        look_At_Player();
        isAttacking=true;
        Zombie2.SetDestination(Player_Position.position);

    }
    public void look_At_Player()
    {
        Vector3 direction = (Player_Position.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);
    }
    public void zombie_Hunt()
    {
        int preyID = Random.Range(0, Prey_points.Length);
        //if (currentTransformIndex == targetID)
        //{
        //    targetID = targetID==Target_points.Length ? targetID - 1 : targetID + 1;
        //}
        Zombie2.SetDestination(Prey_points[preyID].position);
        Zombie2.transform.LookAt(Prey_points[preyID].position);
        currentPreyIndex = preyID;
    }


    public void update_animation()
    {
        if (isAttacking && dist <= Zombie2.stoppingDistance)
        {
            
          play_animstate("ZOMBIE_ATTACK") ;
        
        }
        else if(ishunting)
        {
            Zombie2.speed = 8;
            play_animstate("ZOMBIE_RUNNING");
        }
        else if (isPreying)
        {
            play_animstate("ZOMBIE_WALK");
        }
        else if (isPreying && !isAttacking)
        {
            play_animstate("ZOMBIE_BITING");
        }
    }

    private void play_animstate(string state)
    {
        if (currentstate == state)
        {
            return;
        }
        Play_anim.Play(state);
        currentstate = state;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, lookradius);
    }

}
