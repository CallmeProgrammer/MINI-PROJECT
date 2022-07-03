using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill_Player : MonoBehaviour
{
    public float Current_Health;
    public Image HealthBar;
    public GameObject Damage_Screen;
    public float delay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Damage_Screen.SetActive(false);
        Invoke("Disable_damage_screen", delay);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Reduce_PlayerHealth()
    {
        Player_Health.health_Instance.health -= Player_Health.health_Instance.damage;
        Damage_Screen.SetActive(true);
        Current_Health = Player_Health.health_Instance.health;
        HealthBar.fillAmount -= 0.1f;

    }
    public void Disable_damage_screen()
    {
        Damage_Screen.SetActive(false);
    }
}