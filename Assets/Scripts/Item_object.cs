using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_object : MonoBehaviour
{
    public GameObject GUN;

    public Camera obj_cam;
    public bool isGunPicked;
   
    public float range = 50f;
    RaycastHit hit;
    public Transform equip_pos;

    //public RawImage image;
    public bool ishitting;
    public static Item_object object_instance;

    public void Awake()
    {
        if (object_instance != null)
        {
            return;
        }
        object_instance = this;
    }
        // Start is called before the first frame update
    void Start()
    {
        GUN.GetComponent<Gun>().enabled = false;
        
        // image.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
           


        if (Physics.Raycast(obj_cam.transform.position, obj_cam.transform.forward, out hit, range))
        {
           

            if(hit.transform.tag == "Gun")
            {
                ishitting = true;
                UI_Manager.UI_instance.enable_select_txt();
                GUN.GetComponent<Outline>().enabled = true;
            }
            else
            {
                UI_Manager.UI_instance.disable_select_txt();
                GUN.GetComponent<Outline>().enabled = false;
            }
            Debug.Log(hit.transform.name);
         
            if (hit.transform.GetComponent<Gun>() && Input.GetKey(KeyCode.E))
            {
                UI_Manager.UI_instance.disable_select_txt();
                GUN.transform.position = equip_pos.position;
                GUN.transform.parent = equip_pos;
                GUN.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                GUN.GetComponent<Rigidbody>().isKinematic = true;
                GUN.GetComponent<Gun>().enabled = true;
                isGunPicked = true;
            }


        }
        else if(isGunPicked && Input.GetKey(KeyCode.F))
        {
            Drop();
        }
    }
    public void Drop()
    {
        GUN.transform.parent = null;
        GUN.GetComponent<Rigidbody>().isKinematic = false;
        isGunPicked = false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawRay(obj_cam.transform.position, Vector3.forward * range);
    }
}
