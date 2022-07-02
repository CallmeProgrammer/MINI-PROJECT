using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject Weapon_select_text;

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
}
