using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public GameObject Normal_glass;
    public GameObject Broken_glass;
    // Start is called befor   e the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Glass_objs")
        {
            Destroy(Broken_glass,10f);
        }
    }
    void Start()
    {
        Normal_glass.SetActive(true);
        Broken_glass.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Normal_glass.SetActive(false);
        Broken_glass.SetActive(true);
    }
}
