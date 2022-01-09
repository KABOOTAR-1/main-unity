using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class jointscripts : MonoBehaviour
{
    public CapsuleCollider cc;
    public bool move;
    GameObject enemy;
   
    public Vector3 check;
   public float y;
 
    public bool check2;
    public animationcontroller anime;
   [SerializeField] private Animator anime1;
   static int x=100;
    private void Awake()
    { 
    }
    void Start()
    {
        move = false;

        y = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == cc)
        {
            enemy = other.gameObject;
            y = 3;
            move = true;
           

        }

        if(other.CompareTag("enemy") &&anime.y==0 && other == cc && !anime1.GetCurrentAnimatorStateInfo(0).IsName("block"))
        {
            x = x - 10;
            playerhealthscript.instance.SetHealth(x);
            Debug.Log("Hit");
           
        }
        if (other.CompareTag("enemy") && anime.y>0 )
        {

            Debug.Log("Stay hit");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other==cc)
        move = false;
    }

    private void Update()
    {
        if (y >0 && !Input.GetKey(KeyCode.S) && move == true && tags.MoveOnWall == true )
        {
            enemy.transform.position += new Vector3(0,0,3f*Time.deltaTime);
        }

        if (x == 0)
        {
            tags.EnemyDead = true;

        }

    }
    
 }
