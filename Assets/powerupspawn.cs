using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupspawn : MonoBehaviour
{
    public float spawnRate = 15;
    private float cTime;
    private float spawnDistance = 8;
    public GameObject powerUP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cTime -= Time.deltaTime;

        if (cTime <= 0)
        {
            spawnDistance = Random.Range(3, 9);
            cTime = spawnRate;

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(powerUP, transform.position + offset, Quaternion.identity);
        }
    }
}
