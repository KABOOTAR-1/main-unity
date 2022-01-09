using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerhealthscript : MonoBehaviour
{
    public Slider health;
    public static playerhealthscript instance;

    private void Start()
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

    // Update is called once per frame
    void Update()
    {

    }
    public void SetMaxHealth(int maxhealth)
    {
        health.maxValue = maxhealth;
        health.value = maxhealth;
    }

    public void SetHealth(int Cureenthealth)
    {
        health.value = Cureenthealth;
    }
}
