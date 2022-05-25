using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Damage and Range")]
    public float damage = 10f;
    public float range = 1000f;
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

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadtime = 1f;
    private bool isreloading = false;



    
    //public Transform bulletcase_pos;

    public static Gun Gun_instance;

    // Start is called before the first frame update
    void Start()
    {
       if(currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
        
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
       // actions.Player.Shoot.started += ctx => shoot();
        //actions.Player.Shoot.canceled += ctx =>stop_muzzleflash();
    }

    // Update is called once per frame
    void Update()
    {
        if (isreloading)
            return;

        if(currentAmmo <= 0)
        {
           StartCoroutine(Reload());
            return;
        }
        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= nexttimetofire)
        {
            nexttimetofire = Time.time + 1f / firerate;
            muzzle_flash.Play();
            
            shoot();
        }
        
    }
     
    IEnumerator Reload()
    {
        isreloading = true;
        yield return new WaitForSeconds(reloadtime);
        currentAmmo = maxAmmo;
        isreloading = false; 
    }

    public void shoot()
    {
       //Declaring Raycast
        RaycastHit hit;


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

            //Obtaining functions from another script
            Target target = hit.transform.GetComponent<Target>();
            if(target !=null)
            {
                target.take_damage(damage);
            }
          
            Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));

            //
         
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
