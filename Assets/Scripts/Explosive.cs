using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public GameObject Explosion_Effect;
    public GameObject Fire_Extinguisher;
    public float range=5;
    public float explosion_force = 50f;
    public float delay = 1f;
    public float dist;
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

            WALL_BREAK.wall_break_instance.explode_Wall();
            WALL_BREAK.wall_break_instance.Explosion_in_range = true;

            if (rig != null)
            {
                rig.AddExplosionForce(explosion_force, transform.position, range, 1f, ForceMode.Impulse);

            }
            //if (dist <= range)
            //{
            //    WALL_BREAK.wall_break_instance.Explosion_in_range = true;
            //}

            //if (dist <= range && WALL_BREAK.wall_break_instance.Explosion_in_range)
            //{
            //    WALL_BREAK.wall_break_instance.explode_Wall();
            //}

        }
        Instantiate(Explosion_Effect, transform.position, transform.rotation);
        gameObject.SetActive(false);

      
    }
    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(WALL_BREAK.wall_break_instance.wall_Pos.position, transform.position);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
