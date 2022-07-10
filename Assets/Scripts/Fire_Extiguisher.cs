using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Extiguisher : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 50f;
    public float force = 700f;
    public float countdown;
    public bool hasExploded = false;
    public GameObject explosioneffect;
    public static Fire_Extiguisher Explosion_instance;
    // Start is called before the first frame update
    void Start()
    {
        //countdown = delay;
    }
    private void Awake()
    {
        Explosion_instance = this;
        if(Explosion_instance != null)
        {
            return;
        }
        Explosion_instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        //countdown -= Time.deltaTime;
        //if (countdown <= 0f && !hasExploded)
        //{
        //    explode();
        //    hasExploded = true;
        //}
            
        
    }
    public void explode()
    {
        //Instantiate(explosioneffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
          Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
           if(rb != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(force, transform.position, radius);
                //Instantiate(explosioneffect, transform.position, transform.rotation);
            }

        }
        Destroy(gameObject);

    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
