using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Spawner : MonoBehaviour
{
    public Transform[] Health_Points;
    public float No_Health_Points =9;

    public GameObject Health;
    public static Health_Spawner health_Spawner_instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if(health_Spawner_instance == null)
        {
            return;
        }
        health_Spawner_instance = this; 
    }
    void Start()
    {
        for(int i = 0; i < Health_Points.Length; i++)
        {
            Spawn_health();
        }
      
    }
    // Update is called once per frame
    void Update()
    {
       
            //for (int i = 0; i < Health_Points.Length; i++)
            //{
            //    Spawn_health();
            //}
        
    }
    public void Spawn_health()
    {
        int healthID = Random.Range(0, Health_Points.Length);
        GameObject hel = Instantiate(Health, Health_Points[healthID].transform.position, Health_Points[healthID].transform.rotation);
        //GameObject Zob1 = Instantiate(zombie2, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
        hel.transform.parent = transform;
    }
}
