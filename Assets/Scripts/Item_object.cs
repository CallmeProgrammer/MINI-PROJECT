using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_object : MonoBehaviour
{
    public GameObject Gun;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setactive()
    {
        //Gun.SetActive(false);
    }
    public void set_inactive()
    {
        Gun.SetActive(false);
    }
}
