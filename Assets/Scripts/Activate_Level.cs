using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Level : MonoBehaviour
{
    public GameObject Death_trigger;
    public GameObject ObjectivePanel1;



    public static Activate_Level Activatelevel_instance;
    // Start is called before the first frame update

    public void Awake()
    {
        if(Activatelevel_instance != null)
        {
            return;
        }
        Activatelevel_instance = this;
    }
    void Start()
    {
        ObjectivePanel1.SetActive(false);
        Death_trigger.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (First_Floor_DeathTrigger.First_Floor_DeathTrigger_instance.is_entered_firstfloor)
        {
            Invoke("Activate_level", 3);
        }

        if (First_Floor_DeathTrigger.First_Floor_DeathTrigger_instance.is_entered_firstfloor)
        {
            ObjectivePanel1.SetActive(true);

            Destroy(ObjectivePanel1, 5);

            First_Floor_DeathTrigger.First_Floor_DeathTrigger_instance.is_entered_firstfloor = false;


        }
      
    }
    public void Activate_level()
    {
        UI_Manager.UI_instance.Player_healthPanel.SetActive(true);
        ObjectivePanel1.SetActive(true);
        Death_trigger.SetActive(true);

    }
    public void Disable_Objective_Panel()
    {
        ObjectivePanel1.SetActive(false);
    }

}
