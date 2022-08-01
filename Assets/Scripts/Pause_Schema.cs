using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Schema : MonoBehaviour
{
    public GameObject Pause_panel;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Pause_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            isPaused = true;
            Cursor.visible = true;
            Time.timeScale = 0;
            Pause_panel.SetActive(true);

        }
    }   

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        Pause_panel.SetActive(false);
    }

    public void quit_GAme()
    {
        Application.Quit();
    }
}
