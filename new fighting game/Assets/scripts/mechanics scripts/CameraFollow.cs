using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Transform enemy;
    Vector3 pos;
    Vector3 currentcam,offset;
    float z;
    void Start()
    {
        pos = player.position;
        currentcam = transform.position;
       
    }

    void LateUpdate()
    {
        z = (player.transform.position.z + enemy.transform.position.z) / 2;
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y, z);
        transform.position = Vector3.MoveTowards(transform.position, newpos, 8 * Time.deltaTime);
    }
}
