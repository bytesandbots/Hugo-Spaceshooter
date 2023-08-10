using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pouwerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "powerup")
        {
            if (collision.gameObject.name.StartsWith("health"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<health>().Heal(3);
            }
            if (collision.gameObject.name.StartsWith("Dash"))
            {
                StartCoroutine(Dash());
            }
            if (collision.gameObject.name.StartsWith("damage"))
            {
                StartCoroutine(Damage());
            }
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Dash()
    {
        float oldspeed = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>().speed;
        GameObject.FindGameObjectWithTag("Player").GetComponent < playermovement > ().speed =25 ;
        yield return new WaitForSeconds(10);
        GameObject.FindGameObjectWithTag("Player").GetComponent < playermovement > ().speed = oldspeed;

    }

    IEnumerator Damage()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<shooting>().multiShot = true;
        yield return new WaitForSeconds(10);
        GameObject.FindGameObjectWithTag("Player").GetComponent<shooting>().multiShot = false;

    }
}
