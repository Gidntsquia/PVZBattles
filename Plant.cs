using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private static int cost = 100;
    private static float maxHealth = 2000;
    private static float damage = 20;
    private static float shotspeed = 8f;

    public GameObject bullet;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void shoot()
    {
        // Creates a bullet
        Bullet bullet = Instantiate(this.bullet, transform.position, 
                                        transform.rotation, this.transform)
                                        .GetComponent<Bullet>();

        bullet.speed = shotspeed;
        bullet.damage = damage;
    }

    public void button_test()
    {
        shoot();
    }
}
