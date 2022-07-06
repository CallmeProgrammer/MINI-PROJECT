//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Enemy_spawner : MonoBehaviour
//{
//    public GameObject[] spawners;
//    public GameObject zombie;
//    public GameObject zombie2;
//    public enum SpawnState {SPAWNING , WAITING , COUNTING  };
//    public Wave[] waves;
//    public float timeBetweenWaves =3f;
//    public float waveCountdown = 0;

//    private SpawnState state = SpawnState.COUNTING;
//    public int enemiesAlive = 0;
//    public int round = 0;
//    private int currentwave;
//    //public float zombie_count = 1;

//    public int zombie_Amount = 1;
//    public int zombie_count;
//    public List<C



//    // Start is called before the first frame update
//    void Start()
//    {
//        waveCountdown = timeBetweenWaves;

//        currentwave = 0;
//        //for (int i = 0; i <= zombie_Amount; i++)
//        //{
//        //    zombie_Amount = zombie_count;
//        //    Spawn_enemy();
//        //}

//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if(state == SpawnState.WAITING)
//        {

//        }
//        if(waveCountdown <=0)
//        {
//            if(state != SpawnState.SPAWNING)
//            {
//                StartCoroutine(SpawnWave(waves[currentwave]));
//            }
//        }
//        else
//        {
//            waveCountdown -= Time.deltaTime;
//        }

//        }
//    //public void NextWave(int round)
//    //{
//    //    for (int i = 0; i < round; i++)
//    //    {
//    //        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

//    //        GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
           
            
//    //    }
//    //}
//    private IEnumerator SpawnWave(Wave wave)
//    {
//        state = SpawnState.SPAWNING;

//        for(int i=0; i<wave.enemiesAmount; i++)
//        {
//            Spawn_enemy();
//            yield return new WaitForSeconds(wave.delay);
//        }
       

//        state = SpawnState.WAITING;

//        yield break;
//    }
//    private void Spawn_enemy()
//    {
//            int spawnersID = Random.Range(0, spawners.Length);
//            GameObject Zob = Instantiate(zombie, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
//            //GameObject Zob1 = Instantiate(zombie2, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
//            Zob.transform.parent = transform;
//            //Zob1.transform.parent = transform;
//            enemiesAlive++;
        
         
      
//    }
//}
