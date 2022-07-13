using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY_MOVEMENT5 : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform Player_pos;
    public GameObject PLAYER;
    public GameObject Ray_point;
    public float range = 10f;
    public float look_radius = 10f;
    public float attack_radius = 7f;
    public float dist;
    public Transform[] Target_points;
    private Vector3 zom_distance;
    public int currentTransformIndex;
    public int currentAnimIndex;

    public static ENEMY_MOVEMENT5 enemy_instance;

    public string currentstate;
    public Animator anime;
    public int[] anims;
    private float PlayerisinRange;
    public bool isAttacking = false;
    public bool isPatroling = false;
    public bool isChasing = false;
    public RaycastHit hit;
    public bool inattack =false;

    

    // Start is called before the first frame update

     public void Awake()
    {
        if (enemy_instance != null)
        {
            return;
        }
        enemy_instance = this;
    }
    void Start()
    {

        zombie = GetComponent<NavMeshAgent>();
        anime = GetComponent<Animator>();
        playanimstate("ZOMBIE_WALKING");
        zombie_Patrol();

        //Player_pos = GetComponent<Player_New>().Pos;
        //PLAYER = GetComponent<Player_New>().PlayNEW;
        //for (int i = 0; i < Target_points.Length; i++)
        //{
        //    Target_points[i] = transform.GetChild(i).transform;
        //}



    }

    // Update is called once per frame
    void Update()
    {
        //AUDIO.audio_instance.Play_ZombieMoarning_Audio();
        if(!inattack)
        {
            updateanimation();
        }
      
        attack_radius = zombie.stoppingDistance;
        if (Physics.Raycast(Ray_point.transform.position, Ray_point.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {         
                follow_player();
                look_At_Player();
            }       
        } 
         dist = Vector3.Distance(Player_pos.position, transform.position);

        if (Vector3. Distance(Target_points[currentTransformIndex].position, transform.position) <= zombie.stoppingDistance + 1.5f && !isChasing)
        {
            zombie_Patrol();         
            isPatroling = true;
        }

        if (dist <= look_radius && PLAYER.GetComponent<Player_New>())
        {
            follow_player();        
            look_At_Player();
            isChasing = true;

        }
        else if (dist >= look_radius && isChasing)
        {
            isChasing = false;          
            zombie_Patrol();
        }

        //Debug.Log(Distance(Target_points[currentTransformIndex], transform));
        if (Distance(Player_pos, transform) <= zombie.stoppingDistance)
        {
            isAttacking = true;
        }
        else if(Distance(Player_pos, transform) >= zombie.stoppingDistance)
        {
            isAttacking = false;
        }
    }

    
    public float Distance(Transform from, Transform to)
    {
        return Vector3.Distance(from.position, to.position);

    }
    public void look_At_Player()
    {
        Vector3 direction = (Player_pos.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);
    }
    public void follow_player()
    {
        //zombie.SetDestination(Player_pos.position);
        isPatroling = false;
        zombie.destination = Player_pos.position;
    }
    public void zombie_Patrol()
    {
        int targetID = Random.Range(0, Target_points.Length);
        zombie.speed = 2;
        zombie.SetDestination(Target_points[targetID].position);
        zombie.transform.LookAt(Target_points[targetID].position);
        currentTransformIndex = targetID;
    }

    public void updateanimation()
    {
    //    if (Target.target_instance.isDead == true && Target.target_instance.health <=0)
    //    {
    //        anime.SetTrigger("Dead");
            
           
    //    }
        if (dist >= look_radius && isChasing == false)
        {
            //zombie.isStopped = false;
            playanimstate("ZOMBIE5_WALKING");
             zombie.speed = 3;
        }
        else if (Distance(Player_pos, transform) <= zombie.stoppingDistance)
        {
            zombie.isStopped = true;
            int animID = Random.Range(1, 4);
      
            if (currentAnimIndex == 1)
            {
                inattack = true;
                Debug.Log("Playing ATTACK ");
                playanimstate("ZOMBIE5_ATTACK");             
                inattack = false;
            }
            else if(currentAnimIndex == 2)
            {
                inattack = true;
                Debug.Log("Playing BITING ");
                playanimstate("ZOMBIE5_ATTACK2");               
                inattack = false;
            }
            else if(currentAnimIndex == 3)
            {
                inattack = true;
                Debug.Log("Playing SCREAM ");
                playanimstate("ZOMBIE5_KICKING");             
                inattack = false;
            }
            else if(currentAnimIndex == 4)
            {
                inattack = true;
                Debug.Log("Playing SCREAM");
                playanimstate("ZOMBIE5_ATTACK3");              
                inattack = false;
            }
            currentAnimIndex = animID;
        }    
        else if(dist <= look_radius && !isPatroling)
        {
            zombie.isStopped = false;
            playanimstate("ZOMBIE5_RUNNING");
            zombie.speed = 13;
        }
        else if(Target.target_instance.isDead)
        {
            playanimstate("ZOMBIE5_DIE");
        }
       


        //else if (isAttacking && dist >= zombie.stoppingDistance && dist >= look_radius)
        //{
        //    playanimstate("ZOMBIE_WALKING");
        //}
        //else
        //{
        //    playanimstate("ZOMBIE_RUNNING");

        //}
    }
    public void playanimstate(string state)
    {
        if (currentstate == state)
            return;

        anime.Play(state);
        currentstate = state;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_radius);
        Gizmos.DrawWireSphere(transform.position, attack_radius);
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Ray_point.transform.position,Vector3.forward* -1 * range);
    }
  
    
    public void random_anims()
    {
        inattack = false;
    }
    public void random_anims1()
    {
        inattack = true;
    }
}