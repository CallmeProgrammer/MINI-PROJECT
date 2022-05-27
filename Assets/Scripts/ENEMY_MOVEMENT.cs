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
    public Transform[] Target_points;
    // Start is called before the first frame update
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        zombie_Patrol();
        RaycastHit hit;
        if(Physics.Raycast(Ray_point.transform.position,Ray_point.transform.forward,out hit,range))
        {
            if(hit.transform.gameObject.CompareTag("Player"))
            {
                follow_player();
                look_At_Player();
            }
        }
        
        float distance = Vector3.Distance(Player_pos.position, transform.position);
    
        //if(distance<= look_radius)
        //{
        //    follow_player();

            if (distance <= zombie.stoppingDistance)
            {
                
            }
        
        
    }
    
    public void  look_At_Player()
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
        zombie.SetDestination(Target_points[targetID].position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_radius);
    }
}
