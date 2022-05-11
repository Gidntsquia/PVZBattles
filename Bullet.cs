using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private static float lifetime = 5;
    public float damage;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(go());
    }

    private void Update() {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }


    // Bullet will fly until 5 
    private IEnumerator go() 
    {
        
        yield return new WaitForSeconds(lifetime);
        destroy_me();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        print("Hit!");
        if (other.gameObject.tag == "Zombie")
        {
            Zombie victim = other.gameObject.GetComponent<Zombie>();
            victim.do_damage(damage);
            destroy_me();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("Hit! Trigger");
        if (other.gameObject.tag == "Zombie")
        {
            Zombie victim = other.gameObject.GetComponent<Zombie>();
            victim.do_damage(damage);
            destroy_me();
        }
    }

    private void destroy_me()
    {
        Destroy(this.gameObject);
    }


}
