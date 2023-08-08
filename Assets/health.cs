using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public float overallhealth = 5;
    private float curenthealth;
    public Image HealthBar;

    public void TakeDamage(float damage) { 
        curenthealth =curenthealth - damage;
        if (tag == "Player")
        {
            HealthBar.fillAmount = curenthealth / overallhealth;
        }
        if (curenthealth <= 0) { 
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        curenthealth = overallhealth;
        if (tag == "Player")
        {
            HealthBar.fillAmount = curenthealth / overallhealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Enemy") {
            if (collision.gameObject.tag == "Player") {
                TakeDamage(7);
            }
            if (collision.gameObject.tag == "Bulet") {
                Destroy(collision.gameObject);
                TakeDamage(4);
            }
        }
        if (tag == "BOSS")
        {
            if (collision.gameObject.tag == "Player")
            {
                TakeDamage(5);
            }
            if (collision.gameObject.tag == "Bulet")
            {
                Destroy(collision.gameObject);
                TakeDamage(1);
            }
        }
        if (tag == "Player") {
            if (collision.gameObject.tag == "Enemy") {
                TakeDamage(3);
            }
            if (collision.gameObject.tag == "BOSS")
            {
                TakeDamage(6);
            }
        }
        
    }
}
