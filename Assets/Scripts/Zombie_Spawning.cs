using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawning : MonoBehaviour
{
    public Transform[] spawnPoints;
    public int spawnamount;
    public GameObject[] Zombie_Prefabs;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    public float offset;
    public SpawnType spawnType;
    public enum SpawnType { Waves, Once }

   
    // Start is called before the first frame update
    void Start()
    {
        if (spawnType == SpawnType.Once)
        {
            for (int i = 0; i < spawnamount; i++)
            {
                offset += 1f;
                spawn();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnType == SpawnType.Waves)
        {
            if (spawnedObjects.Count == 0)
            {
                for (int i = 0; i < spawnamount; i++)
                {
                    offset += 1f;
                    spawn();
                }
            }
        }
    }
    public void spawn()
    {
        for(int i = 0; i <spawnamount; i++)
        {
            
            Transform spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];
            GameObject spawnObj = Zombie_Prefabs[Random.Range(0, Zombie_Prefabs.Length)];
            spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y + offset, spawnPoint.position.z);
            GameObject obj = Instantiate(spawnObj, spawnPoint.position, transform.rotation);
           spawnObj.transform.parent = transform;
            spawnedObjects.Add(obj);
        }
    }
}
