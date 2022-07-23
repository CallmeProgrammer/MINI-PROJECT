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
    }

    // Update is called once per frame
    void Update()
    {
        //if(GetComponent<Target>().isDead1 == true)
        //{
        //    killcount++;
        //    Update_kill_count();
        //}
        //else if(GetComponent<Target>().isDead2 == true)
        //{
        //    killcount++;
        //    Update_kill_count();
        //}
        //else if (GetComponent<Target>().isDead3 == true)
        //{
        //    killcount++;
        //    Update_kill_count();
        //}
        //else if (GetComponent<Target>().isDead4 == true)
        //{
        //    killcount++;
        //    Update_kill_count();
        //}
        //else if (GetComponent<Target>().isDead5 == true)
        //{
        //    killcount++;
        //    Update_kill_count();
        //}
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

    //public void Update_kill_count()
    //{
    //    zombi_kill_count.text = killcount.ToString();
    //}
    //public void Damage_Screen()
    //{

    //}
}
