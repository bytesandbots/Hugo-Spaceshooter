
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sooting : MonoBehaviour
{
    public GameObject projectil;
    public Transform barrl;
    public float frecency = .9f;
    private float ctime;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(ctime<frecency)
        {
            ctime += Time.deltaTime;

        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject clone = Instantiate(projectil,barrl.position,barrl.rotation);
                Destroy(clone, 3);
                ctime = 0;
            }
        }
    }
}
