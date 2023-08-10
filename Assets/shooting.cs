using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject projectile;
    public float frequency = .5f;
    public Transform[] barrels;
    private float ctime;
    public bool multiShot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ctime >= frequency)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (multiShot)
                {
                    foreach (Transform barrel in barrels)
                    {
                        GameObject clone = Instantiate(projectile, barrel.position, barrel.rotation);
                        Destroy(clone, 3);
                        ctime = 0;
                    }
                }
                else {

                    GameObject clone = Instantiate(projectile, barrels[0].position, barrels[0].rotation);
                    Destroy(clone, 3);
                    ctime = 0;
                }
            }
        }
        else
        {
            ctime += Time.deltaTime;
        }
    }
} 