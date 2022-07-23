using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Floor_DeathTrigger : MonoBehaviour
{
    public static First_Floor_DeathTrigger First_Floor_DeathTrigger_instance;

    private void Awake()
    {
        if (First_Floor_DeathTrigger_instance != null)
        {
            return;
        }
        First_Floor_DeathTrigger_instance = this;

    }

    public bool is_entered_firstfloor = false;
  // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player is here");
            is_entered_firstfloor = true;         
        }
    }
    
   
}
