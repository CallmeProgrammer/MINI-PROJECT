using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_object : MonoBehaviour
{
    public GameObject GUN;
    public GameObject GUN1;

    public Camera obj_cam;
    public bool isGunPicked;
    public bool isShort_GunPicked;
    public int Gun_count;

   
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
        GUN1.GetComponent<Short_Gun>().enabled = false;

        // image.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


        gun_switch();

        if (Physics.Raycast(obj_cam.transform.position, obj_cam.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Gun" )
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
                Gun_count = 0;
            }
            else if (isGunPicked && Gun_count == 0 && Input.GetKey(KeyCode.F))
            {
                Drop();
            }
            //Short GUn 
            if (hit.transform.tag == "Gun1")
            {
                ishitting = true;
                UI_Manager.UI_instance.enable_select_txt();
                GUN1.GetComponent<Outline>().enabled = true;
            }
            else
            {
                UI_Manager.UI_instance.disable_select_txt();
                GUN1.GetComponent<Outline>().enabled = false;
            }
            Debug.Log(hit.transform.name);

            if (hit.transform.GetComponent<Short_Gun>() && Input.GetKey(KeyCode.E))
            {
                UI_Manager.UI_instance.disable_select_txt();
                GUN1.transform.position = equip_pos.position;
                GUN1.transform.parent = equip_pos;
                GUN1.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
                GUN1.GetComponent<Rigidbody>().isKinematic = true;
                GUN1.GetComponent<Short_Gun>().enabled = true;
                isShort_GunPicked = true;
                Gun_count = 1;
            }
            else if (isShort_GunPicked && Gun_count==1 && Input.GetKey(KeyCode.F))
            {
                Drop();
            }

        }
       
    }
    public void Drop()
    {
        GUN.transform.parent = null;
        GUN.GetComponent<Rigidbody>().isKinematic = false;

        GUN1.transform.parent = null;
        GUN1.GetComponent<Rigidbody>().isKinematic = false;
        isGunPicked = false;
        isShort_GunPicked = false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawRay(obj_cam.transform.position, Vector3.forward * range);
    }


    public void gun_switch()
    {
        //if (isGunPicked && isShort_GunPicked)
        //{
            if (Input.GetKey(KeyCode.Alpha1) && Gun_count == 0 && isGunPicked)
            {
                GUN.SetActive(true);
                GUN1.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Alpha2) && Gun_count == 1 && isShort_GunPicked)
            {
                GUN1.SetActive(true);
                GUN.SetActive(false);
            }

        

        
    }
}
