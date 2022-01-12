using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontleftcollider;
    public WheelCollider frontrightcollider;
    public WheelCollider rearleftcollider;
    public WheelCollider rearrightcollider;
    float horizontal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Steer();
    }

    void move()
    {
        rearleftcollider.motorTorque = 500 * Input.GetAxis("Vertical");
        rearrightcollider.motorTorque = 500 * Input.GetAxis("Vertical");
    }
    void Steer()
    {
        horizontal = Input.GetAxis("Horizontal");
        frontleftcollider.steerAngle = 35 * horizontal;
        frontrightcollider.steerAngle = 35 * horizontal;
    }
}
