using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Recoil : MonoBehaviour
{

    public Vector3 upRecoil;
    Vector3 originalRotation;

    public static Gun_Recoil recoil_instance;
    
    public void Awake()
    {
        if (recoil_instance != null)
        {
            return;
        }
        recoil_instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Add_recoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void stop_recoil()
    {
        transform.localEulerAngles = originalRotation;
    }
}
