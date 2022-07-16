using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject[] ZOMBIES;
    public int Zombie_Amount=1;
    public int range=10;
    public int Zombie_Count ;
    public int No_of_Zombies = 70;

    public static Spawners Spawners_instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Spawners_instance != null)
        {
            return;
        }
        Spawners_instance = this;
    }
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("Spawn_enemy", 1);

        if(Zombie_Amount == No_of_Zombies)
        {
            CancelInvoke("spawn_enemy");
        }

        for (int i = 0; i <= Zombie_Count; i++)
        {
            Spawn_enemy();

        }

        //if (Zombie_Amount <=0)
        //{
        //    CancelInvoke("Spawn_enemy");
        //    Debug.Log("Limit Reached");
        //}
        //else
        //{
        //    InvokeRepeating("Spawn_enemy", 2, 5);
        //}

    }
    private void Spawn_enemy()
    {
        if (Zombie_Amount < No_of_Zombies)
        {
            int spawnersID = Random.Range(0, spawners.Length);
            int ZombID = Random.Range(0,ZOMBIES.Length);
            GameObject Zob = Instantiate(ZOMBIES[ZombID], spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
            //GameObject Zob1 = Instantiate(zombie2, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
            Zob.transform.parent = transform;
            Zombie_Amount++;
            //Zob1.transform.parent = transform;
        }
    }
    public void Wave1()
    {

        for (int i = 0; i <= Zombie_Amount; i++)
        {
            Spawn_enemy();
        }

    }

}
