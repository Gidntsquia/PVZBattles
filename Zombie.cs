using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private static float maxSpeed = 1f;
    private static float maxHealth = 200f;
    private Animator animator;

     // Note: Peashooter does 20 damage per shot.
    [Range(0,2000)]
    public float health;
    
    [Range(0,1)]
    public float speed;
    private ZombieSpawner.SpawnDirection spawnDirection;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        speed = 1f;
        animator = GetComponentInChildren<Animator>();
        spawnDirection = Mathf.Abs(Quaternion.Angle(transform.rotation,
                            Quaternion.identity)) < 90 ? 
                            spawnDirection =
                            ZombieSpawner.SpawnDirection.FROM_LEFT :
                            spawnDirection = 
                            ZombieSpawner.SpawnDirection.FROM_RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnDirection == ZombieSpawner.SpawnDirection.FROM_LEFT)
            transform.position += Vector3.left * 
                maxSpeed * speed * Time.deltaTime; 
        else if (spawnDirection == ZombieSpawner.SpawnDirection.FROM_RIGHT)
            transform.position += Vector3.right * 
                maxSpeed * speed * Time.deltaTime; 
    }

    /*  Deals damage to a particular zombie. Returns whether the damage
        killed the zombie. */
    public bool do_damage(float damage) 
    {
        bool result = false;

        // Check if enough damage is dealt to kill the zombie.
        if (health - damage > 0) 
        {
            health = Mathf.Clamp(health -  damage, 0, maxHealth);
        }
        else 
        {
            result = true;
            print("Zombie is dead! It has " + health + " health.");
            // Kill the zombie
            kill();
        }

        return result;
    }

    private bool coroutine_running = false;
    /* Kills the zombie. Destroys it from the hierarchy. */
    public void kill() 
    {
        if (!coroutine_running)
            StartCoroutine(killCoroutine());
    }

    private IEnumerator killCoroutine()
    {
        coroutine_running = true;
        ZombieSpawner parent = GetComponentInParent<ZombieSpawner>();
        parent.removeZombie(this.gameObject);
        speed = 0;

        // Play kill animation
        animator.Play("death_01");
        // Wait for animation to finish
        yield return new
            WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length 
                            + 1.5f);
        

        Destroy(this.gameObject);

        coroutine_running = false;
    }

    public void button_test()
    {
        do_damage(20);
    }

    
}
