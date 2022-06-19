using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WALL_BREAK : MonoBehaviour
{

    public GameObject wall;
    public Rigidbody rb_wall;
    public Transform wall_Pos;
    public static WALL_BREAK wall_break_instance;
    

    public bool Explosion_in_range;

    public void Awake()
    {
        if(wall_break_instance != null)
        {
            return;
        }
        wall_break_instance = this;
    }
    public void Start()
    {
        wall.GetComponent<Rigidbody>().isKinematic = true;
        wall_Pos = GetComponent<Transform>();
    }
    public void explode_Wall()
    {
        wall.GetComponent<Rigidbody>().isKinematic = false;

    }


}
