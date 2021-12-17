using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance;
    public AudioClip pickupsound, deadsound;
    void Start()
    {
        Makeinstance();
    }

    void Makeinstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void picksound()
    {
        AudioSource.PlayClipAtPoint(pickupsound, transform.position);
    }

    public void ded()
    {
        AudioSource.PlayClipAtPoint(deadsound, transform.position);
    }
}
