using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public float health = 100;
    private float damage = 2;
    public GameObject Damage_screen;
    public bool isnot_hurting;
    public static Player_Health health_Instance;


    // Start is called before the first frame update
    void Start()
    {
      Damage_screen.SetActive(false);
    }
    public void Awake()
    {
        if (health_Instance != null)
        {
            return;
        }
        health_Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }


        if (ENEMY_MOVEMENT.enemy_instance.hit.transform.gameObject.CompareTag("Player"))
        {
            ENEMY_MOVEMENT.enemy_instance.follow_player();
            ENEMY_MOVEMENT.enemy_instance.look_At_Player();
            take_damage();
        }
        else if (ENEMY_MOVEMENT.enemy_instance.dist <= ENEMY_MOVEMENT.enemy_instance.attack_radius)
        {
            var color = Damage_screen.GetComponent<Image>().color;
            color.a -= 0f;
            Damage_screen.GetComponent<Image>().color = color;

            Damage_screen.SetActive(false);
        }
        //if (Damage_screen.GetComponent<Image>().color.a > 0)
        //{
        //    isnot_hurting = true;
        //    var color = Damage_screen.GetComponent<Image>().color;
        //    color.a -= 0f;
        //}
    }
    public void take_damage()
    {
        health -= damage;
        Damage_screen.SetActive(true);
        var color = Damage_screen.GetComponent<Image>().color;
        color.a += 76;
        Damage_screen.GetComponent<Image>().color = color;

    }
  
}
