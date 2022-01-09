using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WALL"))
        {
            tags.MoveOnWall = false;
            if (Input.GetKey(KeyCode.D))
            {
                transform.localPosition += new Vector3(0, 0, 0.6f*Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WALL"))
        {
            tags.MoveOnWall = true;
        }
    }
}
