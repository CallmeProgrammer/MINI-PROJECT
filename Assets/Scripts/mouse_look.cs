using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{
    public float mouse_sens = 500f;
    public Transform player_body;

    float x_rotation = 0f;
    //float y_rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
      

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouse_sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_sens * Time.deltaTime;

        x_rotation -= mouseY;
        x_rotation = Mathf.Clamp(x_rotation, -50f, 50f);

        //transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        transform.localEulerAngles = new Vector3(x_rotation, 0f, 0f);

        player_body.Rotate(Vector3.up * mouseX);

    }
}
