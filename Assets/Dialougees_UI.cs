using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialougees_UI : MonoBehaviour
{
    public GameObject Dialougees;
    // Start is called before the first frame update
    void Start()
    {
        Dialougees.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Display_Dialogue", 60);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Destroy_obj();
    }
    public void Destroy_obj()
    {
        Destroy(Dialougees , 90);
    }
    public void Display_Dialogue()
    {
        Dialougees.SetActive(true);
    }
}
