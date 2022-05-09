using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public List<GameObject> zombies;
    public int num_zombies = 0;

    // Start is called before the first frame update
    void Start()
    {
        num_zombies = 0;
        zombies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Creates a zombie in a particular row. Rows start at 1 (top) and go to 5
        (bottom). */
    public void spawn_zombie(int row)
    {
        num_zombies++;
        zombies.Add(Instantiate(zombie, transform.position + Vector3.down * 2 * 
            (row - 1), transform.rotation));
    }

    public void spawn_zombie()
    {
        // Random row 1-5
        int randInt = Random.Range(1, 6);
        spawn_zombie(randInt);
    }

    public void button_test()
    {
        spawn_zombie();
    }
}
