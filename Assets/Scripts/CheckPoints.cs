using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public GameObject Player;
    public List<GameObject> checkpoints;
    public Vector3 vectorPoint;
    public float dead;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y < -dead)
        {
            Player.transform.position = vectorPoint;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = Player.transform.position;
        Destroy(other.gameObject);
    }
}
