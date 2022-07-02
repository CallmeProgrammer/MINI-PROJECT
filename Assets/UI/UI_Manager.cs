using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject Weapon_select_text;
    public GameObject Ar_GunIcon;
    public GameObject Short_GunIcon;

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
        disable_select_txt();
        disable_Ar_Icon();
        disable_Shortgun_Icon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enable_select_txt()
    {
        Weapon_select_text.SetActive(true);
    }
    public void disable_select_txt()
    {
        Weapon_select_text.SetActive(false);
    }

    public void enable_Ar_Icon()
    {
        Ar_GunIcon.SetActive(true);
    }
    public void disable_Ar_Icon()
    {
        Ar_GunIcon.SetActive(false);
    }

    public void enable_Shortgun_Icon()
    {
        Short_GunIcon.SetActive(true);
    }
    public void disable_Shortgun_Icon()
    {
        Short_GunIcon.SetActive(false);
    }


}
