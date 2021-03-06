using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Short_Gun : MonoBehaviour
{
    [Header("Damage and Range")]
    public float damage = 10f;
    public float range = 50f;
    public float obj_range = 20f;
    [Header("Camera for Raycast")]
    public Camera fps_cam;
    [Header("Particle System")]
    public ParticleSystem muzzle_flash;
    public float impact_force = 5f;
 
    public GameObject Normal_glass;
    public GameObject Broken_glass;

    public GameObject impacteffect;
    public GameObject Bloodeffect;
    public TextMeshProUGUI ammoinfo;
 
    public int maxAmmo = 30;
    public int mag_size = 30;
    public int currentAmmo;
    public float reloadtime = 1f;
    private bool isreloading = false;
    public bool isShooting = false;
    public bool isZombie_hitting;
    public Vector3 upRecoil;
    Vector3 originalRotation;

    public RaycastHit hit;








    //public Transform bulletcase_pos;

    public static Short_Gun Gun_instance;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localEulerAngles;
            currentAmmo = maxAmmo;
    }
    public void Awake()
    {
        if(Gun_instance!=null)
        {
            return;
        }
        Gun_instance = this;
  
      
    }

    // Update is called once per frame
    void Update()
    {
        ammoinfo.text =currentAmmo + " / " + maxAmmo;

        if (isreloading)
            return;

        if(currentAmmo <= 0)
        {
           StartCoroutine(Reload());
            return;
        }

        if(Input.GetKey(KeyCode.Mouse0))
        { 
            muzzle_flash.Play();
            AUDIO.audio_instance.Play_ShortGun_Audio();
            AddRecoil();
            shoot();
        }
        else
        {
            stopRecoil();
        }

    }
     
    IEnumerator Reload()
    {
        isreloading = true;
        //yield return new WaitForSeconds(reloadtime);
        yield return 0 ;
        if (mag_size >= maxAmmo && maxAmmo !=0)
        {
            currentAmmo = maxAmmo;
            mag_size -= maxAmmo;
            maxAmmo = 0;
        }   
        else
        {
            currentAmmo = mag_size;
            mag_size = 0;
        }       
        isreloading = false; 
    }

    public void shoot()
    {
       //Declaring Raycast
        
        currentAmmo--;
            //Checking Whether it is hitting an object or not
            if(Physics.Raycast(fps_cam.transform.position, fps_cam.transform.forward, out hit, range))     
            //Displays object name if raycast hit it           
            Debug.Log(hit.transform.name);
            //Checking Whether the raycast is working or not
            Debug.DrawRay(fps_cam.transform.position, fps_cam.transform.forward, Color.red, 0.1f);
            //Checking and inisiating the glass breaking script for glass break effect whenever we shoot the glass
            if (hit.transform.gameObject.GetComponent<Glass_Break>())
            {
                Debug.Log("BREAK");
                //Inisiating the glass breaking script for glass break effect
                hit.transform.gameObject.GetComponent<Glass_Break>().break_glass();
            }
            
            //Obtaining functions from another script
            Target target = hit.transform.GetComponent<Target>();
            if(target !=null && hit.transform.GetComponent<ENEMY_MOVEMENT>())
            {
                target.take_damage1(damage);
            }
            else if (target != null && hit.transform.GetComponent<ENEMY_MOVEMENT>())
            {
                target.take_damage2(damage);
            }
        else if (target != null && hit.transform.GetComponent<ENEMY_MOVEMENT3>())
        {
            target.take_damage3(damage);
        }
        else if (target != null && hit.transform.GetComponent<ENEMY_MOVEMENT4>())
        {
            target.take_damage4(damage);
        }
        else if (target != null && hit.transform.GetComponent<ENEMY_MOVEMENT5>())
        {
            target.take_damage5(damage);
        }

        Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
        if (hit.transform.tag == "Zombie")
        {
            isZombie_hitting = true;
            Instantiate(Bloodeffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }    
    public void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    public void stopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }

    }


  


