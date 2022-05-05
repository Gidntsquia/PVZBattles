using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private static float speed = 1f;
    private static float maxHealth = 200f;
    public float health;
    // Note: Peashooter does 20 damage per shot.


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; 
    }

    /*  Deals damage to a particular zombie. Returns whether the damage
        killed the zombie. */
    public bool do_damage(float damage) 
    {
        bool result = false;
        if (health > 0) 
        {
            health = Mathf.Clamp(health -  damage, 0, maxHealth);
        }
        else 
        {
            result = true;
            print("Zombie is dead! It has " + health + " health.");
            // Kill the zombie
        }

        return result;
    }

    public void button_test()
    {
        do_damage(20);
    }

    
}
