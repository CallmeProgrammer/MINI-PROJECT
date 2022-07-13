using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY_MOVEMENT4 : MonoBehaviour
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

    public static ENEMY_MOVEMENT4 enemy_instance;

    public string currentstate4;
    public Animator anime4;
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
        anime4 = GetComponent<Animator>();
        playanimstate4("ZOMBIE_WALKING");
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
            updateanimation4();
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

    public void updateanimation4()
    {
    //    if (Target.target_instance.isDead == true && Target.target_instance.health <=0)
    //    {
    //        anime.SetTrigger("Dead");
            
           
    //    }
        if (dist >= look_radius && isChasing == false)
        {
            //zombie.isStopped = false;
            playanimstate4("ZOMBIE4_WALKING");
             zombie.speed = 2;
        }
        else if (Distance(Player_pos, transform) <= zombie.stoppingDistance)
        {
            zombie.isStopped = true;
            int animID = Random.Range(1, 4);
      
            if (currentAnimIndex == 1)
            {
                inattack = true;
                Debug.Log("Playing ATTACK ");
                playanimstate4("ZOMBIE4_ATTACK");             
                inattack = false;
            }
            else if(currentAnimIndex == 2)
            {
                inattack = true;
                Debug.Log("Playing BITING ");
                playanimstate4("ZOMBIE4_ATTACK2");               
                inattack = false;
            }
            else if(currentAnimIndex == 3)
            {
                inattack = true;
                Debug.Log("Playing SCREAM ");
                playanimstate4("ZOMBIE4_KICKING");             
                inattack = false;
            }
            else if(currentAnimIndex == 4)
            {
                inattack = true;
                Debug.Log("Playing SCREAM");
                playanimstate4("ZOMBIE4_ATTACK3");              
                inattack = false;
            }
            currentAnimIndex = animID;
        }    
        else if(dist <= look_radius && !isPatroling)
        {
            zombie.isStopped = false;
            playanimstate4("ZOMBIE4_RUNNING");
            zombie.speed = 12;
        }
        else if(Target.target_instance.isDead)
        {
            playanimstate4("ZOMBIE_DIE4");
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
    public void playanimstate4(string state4)
    {
        if (currentstate4 == state4)
            return;

        anime4.Play(state4);
        currentstate4 = state4;
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