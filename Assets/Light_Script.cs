using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Script : MonoBehaviour
{
    public GameObject Night_effect;
    public GameObject Mrng_effect;

    // Start is called before the first frame update
    void Start()
    {
        Night_effect.SetActive(false);
        Mrng_effect.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Night_effect.SetActive(true);
            Mrng_effect.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
