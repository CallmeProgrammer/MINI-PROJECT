using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public float health = 1000;
    public float damage = 2;
    public bool isnot_hurting;
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
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);

        }
        
    }
  


}
