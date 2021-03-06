using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Damage and Range")]
    public float damage = 10f;
    public float range = 1000f;
    public float obj_range = 20f;
    [Header("Input System")]
    public Input_actions actions;
    [Header("Bullet Prefab")]
    public GameObject Bullet_case;
    [Header("Camera for Raycast")]
    public Camera fps_cam;
    [Header("Particle System")]
    public ParticleSystem muzzle_flash;
    public float impact_force = 5f;
    public float firerate = 15f;
    private float nexttimetofire = 0f;
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
    public bool isZombie_hitting = false;

    public Animator anim;

    public RaycastHit hit;



    //public Transform bulletcase_pos;

    public static Gun Gun_instance;

    // Start is called before the first frame update
    void Start()
    {
      
            currentAmmo = maxAmmo;
        anim = GetComponent<Animator>();

    }
    public void Awake()
    {
        if(Gun_instance!=null)
        {
            return;
        }
        Gun_instance = this;
        //Defining input actions
        actions = new Input_actions();
        actions.Player.Shoot.performed +=ctx=> shoot();
      
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
       
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nexttimetofire)
        {
            nexttimetofire = Time.time + 1f / firerate;
            //AUDIO.audio_instance.Play_AK47_Sound();
            muzzle_flash.Play();
            isShooting = true;
            shoot();
        }
        //if(Input.GetKey(KeyCode.Mouse0))
        //{
        //    AUDIO.audio_instance.Play_AK47_Sound();
        //    muzzle_flash.Play();
        //    isShooting = true;
        //    shoot();
        //}

        if (maxAmmo == 0 && currentAmmo == 0)
        {
            GetComponent<Gun>().enabled = false;
        }

        //if (GetComponent<Short_Gun>().maxAmmo == 0 && GetComponent<Short_Gun>().currentAmmo == 0)
        //{
        //    GetComponent<Short_Gun>().enabled = false;
        //}




    }

    IEnumerator Reload()
    {
        isreloading = true;
        //yield return new WaitForSeconds(reloadtime);
        yield return 0 ;
        if (mag_size >= maxAmmo && maxAmmo != 0)
        {
            currentAmmo = maxAmmo;

            if(currentAmmo==0)
            {
                currentAmmo += 30;
            }          
            maxAmmo -= 30;
            //maxAmmo = 0;
        }

        else
        {
            currentAmmo = maxAmmo;
            mag_size = 0;
        }


        isreloading = false; 
    }
    
    public void shoot()
    {
       //Declaring Raycast
        RaycastHit hit;
        currentAmmo--;

        //Checking Whether it is hitting an object or not
        if (Physics.Raycast(fps_cam.transform.position, fps_cam.transform.forward, out hit, range))
        {
           
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
            //
            if(hit.transform.gameObject.GetComponent<Fire_Extiguisher>())
            {
                Fire_Extiguisher.Explosion_instance.explode();
                //Instantiate(Fire_Extiguisher.Explosion_instance.explosioneffect, hit.point, Quaternion.LookRotation(hit.normal));

            }
            //
            //Obtaining functions from another script
            Target target = hit.transform.GetComponent<Target>();
            if(target !=null && hit.transform.GetComponent<ENEMY_MOVEMENT>())
            {
                target.take_damage1(damage);
            }
            else if (target != null && hit.transform.GetComponent<ENEMY_MOVEMENT2>())
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

            if(hit.transform.tag == "Zombie")
            {
                isZombie_hitting = true;
                Instantiate(Bloodeffect, hit.point, Quaternion.LookRotation(hit.normal));
            
            }

        }
    
        Debug.Log("pressed shoot");
    }

    //NEW INPUTSYSTEM
    private void OnEnable()
    {
        if (actions != null)
            actions.Enable();
    }
    private void OnDisable()
    {
        if (actions != null)
            actions.Disable();
    }
}
