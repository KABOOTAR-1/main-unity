using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyJoints : MonoBehaviour
{
    public CapsuleCollider cc;
    public bool enemy_move;
    GameObject Player;
    public Vector3 check;
    public float y;
    public bool check2;
    public enemyanimation anime;
    public Animator anime1;
    public Animator anime2;
    static int x = 100;
    // Start is called before the first frame update
    void Start()
    {
        enemy_move = false;

        y = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == cc)
        {
            Player = cc.gameObject;
            y = 3;
            enemy_move = true;


        }

        if (other.CompareTag("Player") && anime.y == 0 && other == cc && !anime2.GetCurrentAnimatorStateInfo(0).IsName("block"))
        {
            x = x - 10;
            Debug.Log("EnemyHit");
            healthscript.instance.SetHealth(x);
        }
        if (other.CompareTag("Player") && anime.y > 0)
        {

            Debug.Log("Stay hit");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == cc)
           enemy_move = false;
    }

    private void Update()
    {
        if (y > 0 && !Input.GetKey(KeyCode.S) && enemy_move == true && !anime1.GetCurrentAnimatorStateInfo(0).IsName("uppercut")&& tags.MoveOnWall== true && !anime2.GetCurrentAnimatorStateInfo(0).IsName("block"))
        {
            Player.transform.position -= new Vector3(0, 0, 3f * Time.deltaTime);
        }


        if (x == 0)
        {
            anime2.SetBool("death", true);
            tags.PlayerDead = true;
        }
       

    }
}
