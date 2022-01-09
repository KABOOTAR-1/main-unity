using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
public class GameManager : MonoBehaviour
{
    public dronecontroller drone;
    public Button flybutton,landbutton;
    public GameObject movement;
    public ARRaycastManager raycast;
    public ARPlaneManager plane;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject drone_prefab;
    struct droneanimationcontroller
    {
        public bool moving;
        public bool interpolateasec;
        public bool interpolatedesc;
        public float axis;
        public float direction;
    }

    droneanimationcontroller movingleft;
    droneanimationcontroller movingback;
    void Start()
    {
        flybutton.onClick.AddListener(eventonclickflybutton);
        landbutton.onClick.AddListener(eventonclicklandbutton);
        movement.gameObject.SetActive(false);
        movingleft.moving = false;
        movingback.moving = false;
    }

    // Update is called once per frame
    void Update()
    {
       
       // float sx = Input.GetAxis("Horizontal");
        //float sz = Input.GetAxis("Vertical");

        UpdateControls(ref movingleft);
        UpdateControls(ref movingback);

        drone.move(movingleft.axis*movingleft.direction, movingback.axis*movingback.direction);

        if (drone.isidle())
        {
            UpdateAr();
        }
    }

    void UpdateAr()
    {
        Vector2 screenpostition = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f,1f));

        raycast.Raycast(screenpostition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds);

        if (hits.Count > 0)
        {
            if (plane.GetPlane(hits[0].trackableId).alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
            {
                Pose pose = hits[0].pose;
                drone_prefab.transform.position = pose.position;
                drone_prefab.SetActive(true);
            }
        }
    }
    public void eventonclickflybutton()
    {
        if (drone.isidle())
        {
            drone.takeoff();
            flybutton.gameObject.SetActive(false);
            movement.gameObject.SetActive(true);
        }
    }
    public void eventonclicklandbutton()
    {
        if (drone.flying())
        {
            drone.land();
            flybutton.gameObject.SetActive(true);
            movement.gameObject.SetActive(false);
        }

    }

    void UpdateControls( ref droneanimationcontroller control)
    {
        if(control.moving|| control.interpolateasec|| control.interpolatedesc)
        {
            if (control.interpolateasec)
            {
                control.axis += 0.05f;

                if (control.axis >= 1)
                {
                    control.axis = 1;
                    control.interpolateasec = false;
                    control.interpolatedesc = true;
                }
            }
            else if (!control.moving)
            {
                control.axis -= 0.05f;
                if (control.axis <= 0)
                {
                    control.axis = 0;
                    control.interpolatedesc = false;
                }
            }
            }
        }
    

    public void eventonleftbuttonrelease()
    {
        movingleft.moving = false;
    }

    public void eventonleftbuttonpressed()
    {
        movingleft.moving = true;
        movingleft.interpolateasec = true;
        movingleft.direction = -1;
    }

    public void eventonrightbuttonrelease()
    {
        movingleft.moving = false;
    }

    public void eventonrightbuttonpressed()
    {
        movingleft.moving = true;
        movingleft.interpolateasec = true;
        movingleft.direction = 1;
    }

    public void eventonbackbuttonrelease()
    {
        movingback.moving = false;
    }

    public void eventonbackbuttonpress()
    {
        movingback.moving = true;
        movingback.interpolateasec = true;
        movingback.direction = -1;
    }

    public void eventonfrontbuttonrelease()
    {
        movingback.moving = false;
    }

    public void eventonfrontbuttonpressed()
    {
        movingback.moving = true;
        movingback.interpolateasec = true;
        movingback.direction = 1;
    }
}
