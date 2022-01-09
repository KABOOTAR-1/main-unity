using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject arcamera;
    public GameObject smoke;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootballon()
    {
        RaycastHit hit;
        if (Physics.Raycast(arcamera.transform.position, arcamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "ballon")
            {
                Destroy(hit.transform.gameObject);

                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
