using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Objective_Manager : MonoBehaviour
{
    public float objective1_kill_amount = 40; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KILL_COUNTER.kill_count_instance.is_level_cleared)
        {
            Time.timeScale = 0;     
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;



        }

    }
}
