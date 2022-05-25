using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public List<GameObject> zombies;
    public int num_zombies = 0;

    public enum SpawnDirection
    {
        FROM_LEFT,
        FROM_RIGHT
    }

    public SpawnDirection spawnDirection;

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
    public void spawnZombie(int row, Vector3 topright, Vector3 bottomleft)
    {
        num_zombies++;

        // Note: zPos is always 0 b/c we're in 2D. 
        // yPos is calculated by finding the length of one row, and then
        // multiplying by the number of rows we want, and finally subtracting
        // that from the top of the garden.
        float xPos = spawnDirection == SpawnDirection.FROM_LEFT
                        ? bottomleft.x : topright.x;
        float yPos = topright.y -
                    (((topright.y - bottomleft.y) / 5) * (row - 1)) - 0.33f;
        float zPos = 0f;

        Vector3 zombiePos = new Vector3(xPos, yPos, zPos);
        Quaternion rotation = spawnDirection == SpawnDirection.FROM_LEFT
                            ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        zombies.Add(Instantiate(zombie, zombiePos, rotation, this.transform));
    }

    // Creates a zombie in a random row. This is a shortcut method. 
    public void spawnZombie()
    {
        // Random row 1-5
        int randInt = Random.Range(1, 6);
        spawnZombie(randInt, this.transform.position, this.transform.position);
    }

    // Removes the zombie that calls this
    public void removeZombie(GameObject dead_zombie)
    {
        /* Do some cleanup on ZombieSpawner variables. Doesn't actually
            destroy the zombie from the hierarchy. */
        zombies.Remove(dead_zombie);
        num_zombies--;
    }

    public void button_test()
    {
        spawnZombie();
    }
}
