using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public double health = 100;
    private double damage = 0.01;
    public static Player_Health health_Instance;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    public void take_damage()
    {
        health -= damage;
    }
   
}
