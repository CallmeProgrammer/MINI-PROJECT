using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_spawn : MonoBehaviour
{
    public GameObject swarmerprefab;
    public GameObject bigswarmerprefab;
    public float swarmerIntervel = 3.5f;
    public float bigswarmerIntervel = 10f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerIntervel,swarmerprefab));
        StartCoroutine(spawnEnemy(bigswarmerIntervel,bigswarmerprefab));
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
