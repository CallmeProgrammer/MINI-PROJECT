using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon_Switch : MonoBehaviour
{
    public GameObject[] weapons;
    public int weapon_count = 0;
    public TextMeshProUGUI ammoinfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon_count = 0;
            for(int i = 0; i>weapons.Length; i++)
            {
                if(i!=weapon_count)
                {
                    weapons[i].SetActive(false);
                }
                else
                {
                    weapons[i].SetActive(true);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
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
