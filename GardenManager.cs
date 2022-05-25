using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenManager : MonoBehaviour
{
    private class Tile 
    {
        
    }

    public GameObject[] minions = new GameObject[6];
    public ZombieSpawner zombieSpawner;

    [Range(1, 6)]
    public int selectedMinion = 0;
    // The garden is 5 x 10.
    private Tile[][] garden = new Tile[5][];

    // Start is called before the first frame update
    void Start()
    {
        zombieSpawner.spawnDirection = ZombieSpawner.SpawnDirection.FROM_RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectMinion(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectMinion(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectMinion(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectMinion(4);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            SelectMinion(5);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            SelectMinion(6);

    }

    private void OnMouseEnter() 
    {
        /* Instantiate whatever plant/zombie was selected */
    }

    private void OnMouseDown() 
    {
        // This is the top right of the garden.
        // The first value is the "x" (left/right) and the second
        // value is the "y" (up/down). 
        Vector3 topright = new Vector3(8.30f, 3.30f, 0.00f);
        Vector3 bottomleft = new Vector3(-8.30f, -4.97f, 0.00f);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 10f));


        int row = Mathf.FloorToInt((topright.y - mousePos.y) / 
                    ((topright.y - bottomleft.y) / 5)) + 1;
        int column = Mathf.FloorToInt((mousePos.x - bottomleft.x) / 
                    ((topright.x - bottomleft.x) / 10)) + 1;
        print(new Vector2(row, column));

        // Spawn zombie if the minion is a zombie.
        if (minions[selectedMinion].GetComponentInChildren<Zombie>() 
                    != null)
        {
            // Place zombie
            zombieSpawner.spawnZombie(row, topright, bottomleft);
        }
        else if (minions[selectedMinion].GetComponentInChildren<Plant>() 
                    != null)
        {
            // Place plant

        }


        
    }

    private void SelectMinion(int zombiePos)
    {
        selectedMinion = zombiePos;

        // The first minion in the list is in array pos 0.
        zombieSpawner.zombie = minions[zombiePos - 1];


    }

    
}
