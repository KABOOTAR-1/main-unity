using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemycontroller : MonoBehaviour
{
    public NavMeshAgent navagent;
    public  Transform player_target;
    public enemyanimation enemystate;
    public float x= 0;
    public float diff = tags.check;
    public bool ISCollided=false;
    public CapsuleCollider cap;
    public float h=0;
    public float i;
    public float l;
   
    private void Awake()
    {
        
        navagent = GetComponent<NavMeshAgent>();
       
    }
    void Start()
    {
       
       
    }
    private void Update()
    {
        diff = tags.check;
        if (Input.GetKey(KeyCode.A)||tags.check>1.4f)
        {
            ISCollided = false;
        }
        Chase();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        tags.check = Vector3.Distance(transform.position, player_target.position);
        x = player_target.position.z - transform.position.z;
        if (x<=0)
        {
            
            transform.rotation = Quaternion.Euler(0, Mathf.MoveTowards(180, 0, Time.deltaTime ), 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, Mathf.MoveTowards(0,180,Time.deltaTime), 0);
            
        }
        transform.position = new Vector3(1.15860f, 0, transform.position.z);
        player_target = GameObject.FindGameObjectWithTag("Player").transform;

      
       

    }

    private void Chase()
    {
        navagent.SetDestination(player_target.position);
        if (tags.check < 1.5f )
        {
            
            navagent.speed=0;
            navagent.isStopped = true;
            h = 0;
            
        }
            
        
        if (tags.check >= 1.5f )
        {
            if (h > 2f)
            {
                navagent.SetDestination(player_target.position);
                if (h < 5)

                {
                    navagent.speed = 0.8f;
                    navagent.isStopped = false;
                }
                else
                {
                    h = 0;
                }
               
            }
            else
            {
                h = h + Time.deltaTime;
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == cap)
        {
            ISCollided = true;
        }

        if (other.CompareTag("WALL")){

        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == cap)
        {
            ISCollided = true;
        }
    }

   
}
