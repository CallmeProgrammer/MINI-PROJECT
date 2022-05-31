using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY_MOVEMENT : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform Player_pos;
    public GameObject PLAYER;
    public GameObject Ray_point;
    public float range = 30f;
    public float look_radius = 10f;
    public float attack_radius;
    
    public Transform[] Target_points;
    private Vector3 zom_distance;
    int currentTransformIndex;


   
    //private bool PlayerisinRange = false;
    private bool isAttacking = false;
    private bool isPatroling = false;
    private bool isChasing = false;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
        
        zombie_Patrol();
    }

    // Update is called once per frame
    void Update()
    {

        attack_radius = zombie.stoppingDistance;
        if (Physics.Raycast(Ray_point.transform.position, Ray_point.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                follow_player();
                look_At_Player();
            }
        }
        //if (distance <= look_radius && PLAYER.GetComponent<Player_New>().isRunning)
        //{
        //    isChasing = true;
        //    follow_player();
        //    look_At_Player();
        //}
        //else
        //{
        //    isChasing = false;

        //}

        //if (distance <= zombie.stoppingDistance)
        //{

        //}

        // distance = Distance(Player_pos.position, )
        float dist = Vector3.Distance(Player_pos.position, transform.position);

        if (Vector3. Distance(Target_points[currentTransformIndex].position, transform.position) <= zombie.stoppingDistance + 1.5f && !isChasing)
        {
            zombie_Patrol();
            isPatroling = true;
        }


        if (dist <= look_radius && PLAYER.GetComponent<Player_New>().isRunning)
        {
            isChasing = true;

            follow_player();
            look_At_Player();
        }
        else if(dist >= look_radius && isChasing)
        {
            isChasing = false;
            zombie_Patrol();
        }

        Debug.Log(Distance(Target_points[currentTransformIndex], transform));
        if (Distance(Player_pos, transform) <= zombie.stoppingDistance)
        {
            isAttacking = true;

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
        zombie.SetDestination(Player_pos.position);
    }
    public void zombie_Patrol()
    {
        int targetID = Random.Range(0, Target_points.Length);
        //if (currentTransformIndex == targetID)
        //{
        //    targetID = targetID==Target_points.Length ? targetID - 1 : targetID + 1;
        //}
        zombie.SetDestination(Target_points[targetID].position);
        currentTransformIndex = targetID;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_radius);
    }  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Ray_point.transform.position,Vector3.forward*-1 * range);
    }

  
}