using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activecollider : MonoBehaviour
{
    public GameObject leftarm, rightarm, leftleg, rightleg;
    void Start()
    {
     
        leftarm.SetActive(false);
        rightarm.SetActive(false);
        leftleg.SetActive(false);
        rightleg.SetActive(false);
    }

    // Update is called once per frame
    void Active_LeftArm()
    {
        leftarm.SetActive(true);
    }
    void Active_LeftLeg()
    {
        leftleg.SetActive(true);
    }
    void Active_RightArm()
    {
        rightarm.SetActive(true);
    }
    void Active_RightLeg()
    {
        rightleg.SetActive(true);
    }

    void Deactive_LeftArm()
    {
        if(leftarm.activeInHierarchy)
        leftarm.SetActive(false);
    }

    void Deactive_RightArm()
    {
        if (rightarm.activeInHierarchy)
            rightarm.SetActive(false);
    }
    void Deactive_LeftLeg()
    {
        if (leftleg.activeInHierarchy)
            leftleg.SetActive(false);
    }

    void Deactive_RightLeg()
    {
        if (rightleg.activeInHierarchy)
            rightleg.SetActive(false);
    }



}
