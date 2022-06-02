using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR_OPEN_CLOSE : MonoBehaviour
{
    // Start is called before the first frame update
    public float door_opening = 90f;
    public float door_closing = 0f;
    public GameObject door;

    public void OnTriggerenter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Door_open();
            Debug.Log("PLAYER calling open");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void Door_open()
    {
        Vector3 to = new Vector3(0, door_opening, 0);

        door.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
    }
    public void Door_close()
    {
        Vector3 to = new Vector3(0, door_closing, 0);

        door.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
    }
  
   
    
}
