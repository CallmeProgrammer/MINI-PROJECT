using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_UI : MonoBehaviour
{
    // Start is called before the first frame updat

    public static Pause_UI Pause_instance;

    public void Awake()
    {
        if(Pause_instance != null)
        {
            return;
        }
        Pause_instance = this;
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
       
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    public void Quit()
    {
        Application.Quit();
    } 
    public void Pause_Game()
    {
        Time.timeScale = 0f;
    }
}
