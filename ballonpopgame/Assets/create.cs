using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] ballons;
    void Start()
    {

        StartCoroutine(spawn());
    }

    // Update is called once per frame
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(3f);

        for(int i = 0; i < 3; i++)
        {
            Instantiate(ballons[Random.Range(0, 2)], spawnpoints[i].position, Quaternion.identity); 
        }

        StartCoroutine(spawn());
       
        
    }
}
