using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Explosion : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem Explosion_Effect;
    public GameObject Fire_Extinguisher;
    public GameObject Wall;
    public Transform Wall_Pos;
    public float range = 5;
    public float explosion_force = 50f;
    public float delay = 1f;
    public bool is_exploded =false;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Wall_Pos.position, transform.position);
       
        if(Gun.Gun_instance.hit.transform.tag == "Bomb")
        {
            explode();
           
        }

        if(dist <= range)
        {
            Debug.Log("Wall is in range");
        }
    }

    //[0, 50, 120]
    public void explode()
    {
        gameObject.SetActive(false);
        is_exploded = true;
        Instantiate(Explosion_Effect, transform.position, transform.rotation);
        rb.AddExplosionForce(explosion_force, transform.position, range, 1f, ForceMode.Impulse);
        Wall.GetComponentInChildren<Rigidbody>().isKinematic = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
