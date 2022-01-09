using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class arfacemanager : MonoBehaviour
{
    public Material mat;
    public ARFaceManager arface;
    
    void Start()
    {
        arface = GetComponent<ARFaceManager>();
    }

   
    public void Switch()
    {
        foreach(ARFace face in arface.trackables)
        {
            face.GetComponent<Renderer>().material = mat;
        }
    }
}
