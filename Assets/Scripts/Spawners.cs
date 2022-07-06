using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject zombie;

    public int Zombie_Amount=5;
    public int range=10;
    public int Zombie_Count;

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

        for (int i = 0; i <= Zombie_Amount; i++)
        {
            //Zombie_Count = Zombie_Amount;
            Spawn_enemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Target.target_instance.isDead)
        {
            Zombie_Amount--;
        }

       if(Zombie_Amount <= 0)
        {
            Zombie_Amount = 5;
            Wave1();
        }

    }
    private void Spawn_enemy()
    {      
            int spawnersID = Random.Range(0, spawners.Length);
            GameObject Zob = Instantiate(zombie, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
            //GameObject Zob1 = Instantiate(zombie2, spawners[spawnersID].transform.position, spawners[spawnersID].transform.rotation);
            Zob.transform.parent = transform;
            //Zob1.transform.parent = transform;
    }
    public void Wave1()
    {
       
            for (int i = 0; i <= Zombie_Amount; i++)
            {
                Spawn_enemy();
            }
        
    }
        
}
