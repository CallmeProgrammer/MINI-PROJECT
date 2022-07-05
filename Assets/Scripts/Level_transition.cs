using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_transition : MonoBehaviour
{
    public Transform next_levelpos;
    public Transform Player;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            changepos();
        }
                
    }
    public void changepos()
    {
        Player.position = next_levelpos.position;
    }
}
