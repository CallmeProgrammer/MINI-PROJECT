using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_Gain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            Debug.Log("Health");
            Destroy(collision.gameObject);
            Player_Health.health_Instance.health += 10;
            Kill_Player.Kill_instance.HealthBar.fillAmount += 0.1f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
