using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialougees_UI : MonoBehaviour
{
    public GameObject Dialougees;

    public bool is_dialogue = false;

    public static Dialougees_UI dialougees_instance;
    // Start is called before the first frame update
    public void Awake()
    {
        if(dialougees_instance != null)
        {
            return;
        }
        dialougees_instance = this;
    }


    void Start()
    {
        Dialougees.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_dialogue = true;
            
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void enable_Dialogue()
    {
        Dialougees.SetActive(true);
    }
   
}
