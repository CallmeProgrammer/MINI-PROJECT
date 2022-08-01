using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KILL_COUNTER : MonoBehaviour
{
    public TextMeshProUGUI counter_text;
    public int kills;
    public bool is_level_cleared = false;

    public static KILL_COUNTER kill_count_instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if(kill_count_instance != null)
        {
            return;
        }
        kill_count_instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showkills();

        if(kills == 40)
        {
            is_level_cleared=true;  
        }
    }
    private void showkills()
    {
        counter_text.text = kills.ToString();
    }
    public void addkill()
    {
        kills++;
    }
}
