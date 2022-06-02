using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gun_Switcher : MonoBehaviour
{
    public int selectedweapon = 0;
    public TextMeshProUGUI ammoinfo;
   

    // Start is called before the first frame update
    void Start()
    {
        switch_Weapon();
    }

    // Update is called once per frame
    void Update()
    {

        Gun currentGun = FindObjectOfType<Gun>();
        ammoinfo.text = currentGun.currentAmmo + " / " + currentGun.maxAmmo;
        int previousselected = selectedweapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            selectedweapon++;
            if(selectedweapon == 1)
            {
                selectedweapon = 0;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            selectedweapon--;
            if(selectedweapon == -1)
            {
                selectedweapon = 1;
            }
        }
        if(previousselected != selectedweapon)
        {
            switch_Weapon();
        }
        
    }
    public void switch_Weapon()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectedweapon).gameObject.SetActive(true);
    }
}
