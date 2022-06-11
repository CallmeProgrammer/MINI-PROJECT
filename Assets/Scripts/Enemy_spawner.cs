using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject zombie;
    //public float zombie_count = 1;
    private int wave_num = 0;
    private int zombie_count = 5;
    private int zombiekill_count = 0;

    // Start is called before the first frame update
    void Start()
    {
       // spawners = new GameObject[5];

        for(int i = 0; i<=zombie_count; i++)
        {
            Spawn_enemy();   
            //spawners[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
            //Spawn_enemy();
       // StartWave();

    }


    private void Spawn_enemy()
    {
        int spawnersID = Random.Range(0, spawners.Length);
        GameObject Zob=   Instantiate(zombie, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
        Zob.transform.parent = transform;
    }

    private void StartWave()
    {
        wave_num = 1;
        zombie_count = 2;
        zombiekill_count = 0;

        for(int i =0; i<zombie_count; i++)
        {
            Spawn_enemy();
        }
    }
    //private void Nextwave()
    //{
    //    wave_num++;
    //    zombie_count += 2;
    //    zombiekill_count = 0;

    //    for (int i = 0; i < zombie_count; i++)
    //    {
    //        Spawn_enemy();
    //    }
    //}
}
