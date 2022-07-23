using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Level : MonoBehaviour
{
    public GameObject Death_trigger;
    // Start is called before the first frame update
    void Start()
    {
        Death_trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(First_Floor_DeathTrigger.First_Floor_DeathTrigger_instance.is_entered_firstfloor)
        {
            Invoke("Activate_level", 30);
        }
    }
    public void Activate_level()
    {
        Death_trigger.SetActive(true);
    }
}
