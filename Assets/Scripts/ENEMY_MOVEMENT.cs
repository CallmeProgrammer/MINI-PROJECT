using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY_MOVEMENT : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform Player_pos;
    public GameObject PLAYER;
    public float look_radius = 10f;
    // Start is called before the first frame update
    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        float distance = Vector3.Distance(Player_pos.position, transform.position);
        if(distance<=look_radius)
        {
            follow_player();

            if(distance <= zombie.stoppingDistance)
            {
                look_At_Player();
            }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_radius);
    }
}
