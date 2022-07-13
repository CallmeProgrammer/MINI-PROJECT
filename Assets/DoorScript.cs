using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Rigidbody rb_Door;
    public Transform Player_Position;
    public Transform Door_Pos;
    public GameObject DOOR;
    public bool isOpen = false;
    public bool isRotatingDoor = true;
    public Animator anim;
    public float Door_Radius;
    public float Door_Dist;
    
    public void Update()
    {
        Door_Dist = Vector3.Distance(Player_Position.position, transform.position);
        if(Door_Dist <= Door_Radius)
        {
            DOOR.transform.rotation = Quaternion.Euler(0, 0, 0);
        
            isOpen = true;
        }
        else if (Door_Dist >= Door_Radius)
        {
            DOOR.transform.rotation = Quaternion.Euler(0, 90, 0);
           
            isOpen = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Door_Radius);
     
    }


}

