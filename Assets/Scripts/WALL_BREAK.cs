using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WALL_BREAK : MonoBehaviour
{

    public GameObject wall;
    public void Disable_Kinematic()
    {
        wall.GetComponent<Rigidbody>().isKinematic = false;
    }
}
