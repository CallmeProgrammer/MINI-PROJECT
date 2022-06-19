using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gun_Switcher : MonoBehaviour
{
    //public int selectedweapon = 0;
    //public TextMeshProUGUI ammoinfo;
    public GameObject[] weapons;
    public int weapon_count = 0;


    // Start is called before the first frame update
    void Start()
    {
        //switch_Weapon();
    }

    // Update is called once per frame
    void Update()
    {

        //Gun currentGun = FindObjectOfType<Gun>();
        //ammoinfo.text = currentGun.currentAmmo + " / " + currentGun.maxAmmo;

        //ammoinfo.text = Gun.Gun_instance.currentAmmo + " / " + Gun.Gun_instance.maxAmmo;

        if (Input.GetKeyDown(KeyCode.I))
        {
            weapon_count = 0;
            for (int i = 0; i > weapons.Length; i++)
            {
                if (i != weapon_count)
                {
                    weapons[i].SetActive(false);
                }
                else
                {
                    weapons[i].SetActive(true);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            weapon_count = 1;
            for (int i = 0; i > weapons.Length; i++)
            {
                if (i != weapon_count)
                {
                    weapons[i].SetActive(false);
                }
                else
                {
                    weapons[i].SetActive(true);
                }
            }
        }



    }

}
