using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn_zombie(int row) 
    {
        
        Instantiate(zombie, transform.position + Vector3.down * 2 * (row - 1), 
            transform.rotation);
    }

    public void button_test() 
    {
        int randInt = Random.Range(1, 5);
        spawn_zombie(randInt);
    }
}
