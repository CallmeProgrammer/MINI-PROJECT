using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    public GameObject Ar_GunIcon;
    public GameObject Short_GunIcon;
    public GameObject PlayerDamage_Screen;
    public GameObject Player_healthPanel;
    public GameObject Mission_End_Panel;
    //public TextMeshProUGUI zombi_kill_count;
    //public int killcount;


    public static UI_Manager UI_instance;
    // Start is called before the first frame update

    public void Awake()
    {
        if(UI_instance != null)
        {
            return;
        }
        UI_instance = this;
    }
    void Start()
    {
        disable_Ar_Icon();
        disable_Shortgun_Icon();
        enable_Playerhealth_panel();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
 
//
    public void enable_Ar_Icon()
    {
        Ar_GunIcon.SetActive(true);
    }
    public void disable_Ar_Icon()
    {
        Ar_GunIcon.SetActive(false);
    }
//
    public void enable_Shortgun_Icon()
    {
        Short_GunIcon.SetActive(true);
    }
    public void disable_Shortgun_Icon()
    {
        Short_GunIcon.SetActive(false);
    }
    public void Application_Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    //public void Update_kill_count()
    //{
    //    zombi_kill_count.text = killcount.ToString();
    //}
    //public void Damage_Screen()
    //{

    //}
    public void enable_Playerhealth_panel()
    {
       Player_healthPanel.SetActive(true);
    }
}
