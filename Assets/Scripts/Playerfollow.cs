using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Playerfollow : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.destination = target.position;
    }
}
