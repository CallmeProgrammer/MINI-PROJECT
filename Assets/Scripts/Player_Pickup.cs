using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pickup : MonoBehaviour
{
    public float pickuprange;
    public LayerMask pickup_layer;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,pickuprange,pickup_layer ))
            {
                Debug.Log("Hit: " + hit.transform.name);
                
            }

        }
    }
}
