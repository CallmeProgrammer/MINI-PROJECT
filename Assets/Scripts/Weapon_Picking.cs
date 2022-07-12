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

    //
    public GameObject Weapon_Select_Text;
    public GameObject Health_Select_Text;
    
    //
    public float range = 50f;
    public RaycastHit hit;
    public GameObject Ar_Gun_pos;//Ar GUN
    public Transform Ar_Gun_Position;//Ar GUN
    public GameObject Short_Gun_pos;//Short GUN
    public Transform Short_Gun_Position;//Short GUN
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
        ///////////////////////////////
        Ar_Gun.GetComponent<Outline>().enabled = false;
        Short_Gun.GetComponent<Outline>().enabled = false;
        Knife.GetComponent<Outline>().enabled = false;
        ////////////////////////////////////
        Ar_Gun_pos.GetComponent<Gun>().enabled = false;
        Short_Gun_pos.GetComponent<Short_Gun>().enabled = false;
        /////////////////////////////////////
        Ar_Gun_pos.GetComponent<Rigidbody>().isKinematic = true;
        Short_Gun_pos.GetComponent<Rigidbody>().isKinematic = true;
        Knife_pos.GetComponent<Rigidbody>().isKinematic = true;
        /////////////////////////////////////
        Weapon_Select_Text.SetActive(false);
        Health_Select_Text.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
   

        if (Physics.Raycast(obj_cam.transform.position, obj_cam.transform.forward, out hit, range))
        {
            //Gun Picking
            if(hit.transform.tag == "AR_GUN")
            {
                ishitting = true;
                Weapon_Select_Text.SetActive(true);
                Ar_Gun.GetComponent<Outline>().enabled = true;              
            }
            else
            {
                Weapon_Select_Text.SetActive(false);
                Ar_Gun.GetComponent<Outline>().enabled = false;            
            }

            if(hit.transform.tag == "SHORT_GUN")
            {
                ishitting = true;
                Weapon_Select_Text.SetActive(true);
                Short_Gun.GetComponent<Outline>().enabled = true;
            }
            else
            {              
                Weapon_Select_Text.SetActive(false);
                Short_Gun.GetComponent<Outline>().enabled = false;
            }

            if (hit.transform.tag == "Knife")
            {
                ishitting = true;
                
                Knife.GetComponent<Outline>().enabled = true;
            }
            else
            {
               
                Knife.GetComponent<Outline>().enabled = false;
            }

  
            Debug.Log(hit.transform.name);
//////////////////////////////////////////////////////////////////////////////////////
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
            else if(isAr_GunPicked && Input.GetKey(KeyCode.F))
            {
                isAr_GunPicked = false;
                Ar_Gun_pos.transform.parent = null;
                UI_Manager.UI_instance.disable_Ar_Icon();
                Ar_Gun_pos.GetComponent<Rigidbody>().isKinematic = false;
                Ar_Gun_pos.GetComponent<Gun>().enabled = false;
            }
/////////////////////////////////////////////////////////////////////////////////////////////
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
            else if (isShort_GunPicked && Input.GetKey(KeyCode.F))
            {
                isShort_GunPicked = false;
                Short_Gun_pos.transform.parent = null;
                UI_Manager.UI_instance.disable_Shortgun_Icon();
                Short_Gun_pos.GetComponent<Rigidbody>().isKinematic = false;
                Short_Gun_pos.GetComponent<Short_Gun>().enabled = false;
            }
            //////////////////////////////////////////////////////////////////////////////////////

            if (hit.transform.GetComponent<Short_Gun>().enabled == false && !isShort_GunPicked && Input.GetKeyDown(KeyCode.E))
            {
                Short_Gun_pos.transform.position = Short_Gun_Position.position;
                Short_Gun_pos.transform.parent = Short_Gun_Position;
                Short_Gun_pos.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                Short_Gun_pos.GetComponent<Rigidbody>().isKinematic = true;
                SHORT_GUN();
            }
            else if (hit.transform.GetComponent<Gun>().enabled == false && !isAr_GunPicked && Input.GetKeyDown(KeyCode.E))
            {
                Ar_Gun_pos.transform.position = Ar_Gun_Position.position;
                Ar_Gun_pos.transform.parent= Ar_Gun_Position;
                Ar_Gun_pos.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                Ar_Gun_pos.GetComponent<Rigidbody>().isKinematic = true;
                AR_GUN();
            }
/////////////////////////////////////////////////////////////////////////////////////

            if (hit.transform.tag == "Health" )
            {
                Health_Select_Text.SetActive(true);
                if (Player_Health.health_Instance.health < 100 && Input.GetKey(KeyCode.E))
                {
                    hit.transform.gameObject.SetActive(false);
                    //Health_Spawner.health_Spawner_instance.No_Health_Points--;
                    Player_Health.health_Instance.health += 10;
                    Kill_Player.Kill_instance.HealthBar.fillAmount += 0.3f;
                }              
            
            }
            else
            {
                Health_Select_Text.SetActive(false);
            }
///////////////////////////////////////////////////////////////////////////////////////


        }
        if (isAr_GunPicked && isShort_GunPicked)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AR_GUN();
                Short_Gun_pos.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SHORT_GUN();
                Ar_Gun_pos.SetActive(false);
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
        //Ar_Gun_pos.transform.position =  Ar_Gun_Position.position;
        UI_Manager.UI_instance.enable_Ar_Icon();
        UI_Manager.UI_instance.disable_Shortgun_Icon();
        Ar_Gun_pos.SetActive(true);
    }
    public void SHORT_GUN()
    {
        Short_Gun_pos.GetComponent<Short_Gun>().enabled = true;
        //Short_Gun_pos.transform.position = Short_Gun_Position.position;
        UI_Manager.UI_instance.enable_Shortgun_Icon();
        UI_Manager.UI_instance.disable_Ar_Icon();
        Short_Gun_pos.SetActive(true);
    }
    public void KNIFE()
    {
        Knife_pos.SetActive(true);
    }
}

