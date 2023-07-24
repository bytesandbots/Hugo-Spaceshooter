using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public float overallhealth = 5;
    private float curenthealth;

    public void TakeDamage(float damage) { 
        curenthealth =curenthealth - damage;
        if (curenthealth <= 0) { 
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        curenthealth = overallhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Enemy") {
            if (collision.gameObject.tag == "Bullet") {
                TakeDamage(5);
            }
            if (collision.gameObject.tag == "Bullet") {
                Destroy(collision.gameObject);
                TakeDamage(1);
            }
        }
        if (tag == "Player") {
            if (collision.gameObject.tag == "Enemy") {
                TakeDamage(3);
            }
        }
        
    }
}
