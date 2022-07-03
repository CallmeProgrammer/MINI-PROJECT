using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public Image HealthBar;
    //public float Max_Health = 100f;
   
    
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }
}
