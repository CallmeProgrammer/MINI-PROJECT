using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KILL_COUNTER : MonoBehaviour
{
    public TextMeshProUGUI counter_text;
    int kills;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showkills();
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
