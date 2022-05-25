using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;

    private bool opened = false;
    private Animator anim;



    void Update()
    {
        //This will tell if the player press F on the Keyboard. P.S. You can change the key if you want.
        
    }

    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("You Press F");
          
                if (doorhit.transform.tag == "Door")
                {
                    opened = !opened;
                    if(opened)
                    {
                        anim.SetBool("isIdle", false);
                    }
                    else
                    {
                        anim.SetBool("isOpened", false);
                    }
                   

                }
               
            }
        }
    }
}

