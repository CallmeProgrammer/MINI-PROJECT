using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Picking : MonoBehaviour
{
    //public GameObject Hand_Gun;
    public GameObject Short_Gun;
    public GameObject Ar_Gun;
    public GameObject Knife;

    public Camera obj_cam;
    //public bool isHand_GunPicked;
    public bool isAr_GunPicked;
    public bool isKnifePicked;
    public bool isShort_GunPicked;

    //public int HandGun_count=3;
    public int ARGun_count=4;
    public int Knife_count=1;
    public int ShortGun_count=2;
    
    

    public float range = 50f;
    public RaycastHit hit;
    public GameObject Ar_Gun_pos;//Ar GUN
    public GameObject Short_Gun_pos;//Short GUN
    //public GameObject Hand_Gun_pos;//Hand GUN
    public GameObject Knife_pos;//Dagger

    //public RawImage image;
    public bool ishitting;
    public static Weapon_Picking weapon_instance;

    public void Awake()
    {
        if (weapon_instance != null)
        {
            return;
        }
        weapon_instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Short_Gun_pos.SetActive(false);
        Ar_Gun_pos.SetActive(false);
        //Hand_Gun_pos.SetActive(false);
        Knife_pos.SetActive(false);

        Ar_Gun.GetComponent<Outline>().enabled = false;
        Short_Gun.GetComponent<Outline>().enabled = false;
        Knife.GetComponent<Outline>().enabled = false;

        Ar_Gun_pos.GetComponent<Gun>().enabled = false;
        Short_Gun_pos.GetComponent<Short_Gun>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
   

        if (Physics.Raycast(obj_cam.transform.position, obj_cam.transform.forward, out hit, range))
        {
            //Gun Picking
            if (hit.transform.GetComponent<Outline>())
            {
                ishitting = true;
                UI_Manager.UI_instance.enable_select_txt();
                Ar_Gun.GetComponent<Outline>().enabled = true;
                Short_Gun.GetComponent<Outline>().enabled = true;
                Knife.GetComponent<Outline>().enabled = true;
            }
            else
            {
                UI_Manager.UI_instance.disable_select_txt();
                Ar_Gun.GetComponent<Outline>().enabled = false;
                Short_Gun.GetComponent<Outline>().enabled = false;
                Knife.GetComponent<Outline>().enabled = false;
            }
            Debug.Log(hit.transform.name);

            if(hit.transform.tag == "AR_GUN" && Input.GetKey(KeyCode.E))              
            {
                isAr_GunPicked = true;
                if (isShort_GunPicked)
                {
                    Short_Gun_pos.SetActive(false);
                    Ar_Gun_pos.SetActive(true);
                }
                Ar_Gun.SetActive(false);
                AR_GUN();
            }

            if (hit.transform.tag == "SHORT_GUN" && Input.GetKey(KeyCode.E))
            {
                isShort_GunPicked=true;
                if (isAr_GunPicked)
                {
                    Short_Gun_pos.SetActive(true);
                    Ar_Gun_pos.SetActive(false);
                }
                Short_Gun.SetActive(false);
                SHORT_GUN();
            }
        }

        }
        public void Drop()
        {
            //GUN.transform.parent = null;
            //GUN.GetComponent<Rigidbody>().isKinematic = false;

            //GUN1.transform.parent = null;
            //GUN1.GetComponent<Rigidbody>().isKinematic = false;
            //isGunPicked = false;
            //isShort_GunPicked = false;

            //GUN.GetComponent<Gun>().enabled = false;
            //GUN1.GetComponent<Short_Gun>().enabled = false;

        }
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Debug.DrawRay(obj_cam.transform.position, Vector3.forward * range);
        }
       
    public void AR_GUN()
    {
        Ar_Gun_pos.GetComponent<Gun>().enabled = true;
        Ar_Gun_pos.SetActive(true);
    }
    public void SHORT_GUN()
    {
        Short_Gun_pos.GetComponent<Short_Gun>().enabled = true;
        Short_Gun_pos.SetActive(true);
    }
    public void KNIFE()
    {
        Knife_pos.SetActive(true);
    }
}

