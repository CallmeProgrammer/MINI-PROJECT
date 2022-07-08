using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Rigidbody rb_Door;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb_Door.AddRelativeTorque(new Vector3(20, 0, 20f));
        }
    }



}

