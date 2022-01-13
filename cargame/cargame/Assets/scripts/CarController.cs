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
    Rigidbody rb;
    public Transform com;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.centerOfMass = com.position;
        move();
        Steer();
        rb.AddForce(Vector3.down * 300f);
        if (Input.GetButton("Jump"))
        {
            Drift();
        }
        
        Debug.DrawRay(transform.position, transform.right*Input.GetAxis("Horizontal"),Color.blue);
        Debug.DrawRay(transform.position, rb.velocity.normalized * 3);
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

    void Drift() {

        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * 100f*Time.deltaTime);
    }
}
