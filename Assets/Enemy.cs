using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public Transform Player_pos;
    public NavMeshAgent _enemy;
    public float stopping_distance;
    public Animator anim;
    public float distance;
    public Transform RAY;
    public bool isDEAD;

    // Start is called before the first frame update

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        kill_player();
        _enemy.transform.LookAt(Player_pos);

        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist < stopping_distance)
        {
            StopEnemy();
            anim.SetBool("isinRange", true);
        }
        else if(dist > stopping_distance)
        {
            findtarget();
            anim.SetBool("isinRange", false);
        }
        else if (gameObject.GetComponent<Target>().isDead == true)
        {
                anim.SetBool("isDead", true);          
        }

    
        

    }

    public void findtarget()
    {
        _enemy.isStopped = false;  
        _enemy.SetDestination(Player.transform.position);
    }
  
    public void StopEnemy()
    {
        _enemy.isStopped = true;
    }

    public void kill_player()
    {
        RaycastHit hit;

        if (Physics.Raycast(RAY.transform.position, Vector3.forward, out hit, distance));
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.GetComponent<Rigidbody>())
            {
                Player_Health.health_Instance.take_damage();
                Debug.Log("working");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(RAY.position, Vector3.forward * distance*-1);
    }

}
