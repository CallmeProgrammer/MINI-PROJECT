using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Locked : MonoBehaviour
{
    public GameObject Door_Locked_text;
    
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Door_Locked_text.SetActive(true);
        }
    }

    void Start()
    {
        Door_Locked_text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Door_Locked_text.SetActive(false);
    }
   
}
