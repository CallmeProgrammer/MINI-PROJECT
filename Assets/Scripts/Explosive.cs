using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public GameObject Explosion_Effect;
    public float range=5;
    public float explosion_force = 50f;
    public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public void Explosion()
    {
        Invoke("Explode", delay);
        
    }
    public void Explode()
    {

        
        Collider[] Colliders = Physics.OverlapSphere(transform.position, range);

        foreach(Collider near in Colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

            if(rig != null)
            {
                rig.AddExplosionForce(explosion_force, transform.position, range, 1f, ForceMode.Impulse);
                gameObject.GetComponent<WALL_BREAK>().Disable_Kinematic();

            }
           
        }
        Instantiate(Explosion_Effect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        gameObject.GetComponent<Explosive>().enabled = false;


    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
