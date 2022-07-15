using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pause_panel;
    void Start()
    {
        Pause_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        Pause_panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Pause_panel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Restart()
    {

    }
    public void Quit()
    {
        Application.Quit();
    } 
    public void Display_PausePanel()
    {
        Pause_panel.SetActive(true);
    }
    
}
