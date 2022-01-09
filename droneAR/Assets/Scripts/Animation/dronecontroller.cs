using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronecontroller : MonoBehaviour
{
   
    enum dronestate
    {
        idle,
        start_takeoff,
        takeoff,
        movingup,flying,startlanding,
        landing,landed,stopengine
    }

    dronestate _state;
    Animator anime;
    Vector3 speed = new Vector3(0,0,0);

    public bool isidle()
    {
        return (_state == dronestate.idle);
    }

    public  void takeoff()
    {
        _state = dronestate.start_takeoff;
    }
    
    public bool flying()
    {
        return (_state == dronestate.flying);
    }

    public void land()
    {
        _state = dronestate.startlanding;
    }
   void Start()
    {
        anime = GetComponent<Animator>();
    }

   
    public void move(float sx,float sy)
    {
        speed.x = sx;
        speed.z = sy;
        UpdateDrone();
    }
    void UpdateDrone()
    {
        
        switch (_state)
        {
            case dronestate.idle:
                break;

            case dronestate.start_takeoff:
                anime.SetBool("TakeOff", true);
                _state = dronestate.takeoff;
                break;

            case dronestate.takeoff:
                if (anime.GetBool("TakeOff") == false)
                {
                    _state = dronestate.movingup;
                }
                break;
            case dronestate.movingup:
                if (anime.GetBool("MoveUp") == false)
                {
                    _state = dronestate.flying;
                }
                break;

            case dronestate.flying:
                float anglez = -30f * speed.x;
                float anglex = -30f * speed.z;
                Vector3 rotation = transform.rotation.eulerAngles;
                transform.localPosition += speed * Time.deltaTime * 4f;
                transform.localRotation = Quaternion.Euler(anglex, rotation.y, anglez);
                break;

            case dronestate.startlanding:
                anime.SetBool("MoveDown", true);
                _state = dronestate.landing;
                break;

            case dronestate.landing:
                if (anime.GetBool("MoveDown") == false)
                {
                    _state = dronestate.landed;
                }
                break;

            case dronestate.landed:
                anime.SetBool("Land", true);
                _state = dronestate.stopengine;
                break;

            case dronestate.stopengine:
                if (anime.GetBool("Land") == false)
                {
                    _state = dronestate.idle;
                }
                break;
        }
       
    }
}
