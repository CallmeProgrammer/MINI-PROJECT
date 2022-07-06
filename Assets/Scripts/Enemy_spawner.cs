using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject zombie;
    public GameObject zombie2;

    public int enemiesAlive = 0;
    public int round = 0;

    //public float zombie_count = 1;

    public int zombie_Amount = 1;
    public int zombie_count;




    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i <= zombie_Amount; i++)
        //{
        //    zombie_Amount = zombie_count;
        //    Spawn_enemy();
        //}

    }
    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {
            round++;
            Spawn_enemy(round);
         
        }

            //for (int i = 0; i <= zombie_Amount; i++)
            //{
            //    zombie_Amount = zombie_count;
            //    Spawn_enemy();
            //}
            //if (zombie_count <= zombie_Amount)
            //{
            //    zombie_Amount *= 2;
            //    Spawn_enemy();
            //}

        }
    //public void NextWave(int round)
    //{
    //    for (int i = 0; i < round; i++)
    //    {
    //        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

    //        GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
           
            
    //    }
    //}
    private void Spawn_enemy(int round)
    {
        for (int i = 0; i < round; i++)
        {
            int spawnersID = Random.Range(0, spawners.Length);
            GameObject Zob = Instantiate(zombie, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
            //GameObject Zob1 = Instantiate(zombie2, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
            Zob.transform.parent = transform;
            //Zob1.transform.parent = transform;
            enemiesAlive++;
        }
         
      
    }
}
