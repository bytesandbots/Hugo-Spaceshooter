using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforward : MonoBehaviour
{
    public float speed = 5;
    public bool bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

        }
        else {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
       
    }
}
