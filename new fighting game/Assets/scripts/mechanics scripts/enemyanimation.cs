using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyanimation : MonoBehaviour
{
    public Animator anime;
    public Animator anime1;
    int z;
    public float x = 0;
    public float y=0;
    public float xheck = 0;
    public Transform Jump_Check;
    public LayerMask Ground;
    public Vector3 vel;
    public CharacterController cc;
    public bool isGrounded;
    public AnimationClip clip;
    public bool isJumping = true;
    private enemycontroller ec;
    public float nice;
    public bool ataack;
    float h1;

    public state enemycheck;
    private void Awake()
    {
        ataack = false;
    }
    void Start()
    {
        tags.enemyattack = 0;
        anime = GetComponent<Animator>();
        z = Animator.StringToHash("velocity");
        ec = GetComponent<enemycontroller>();
        enemycheck = state.walk;
        anime.SetBool("Punch", false);
        InvokeRepeating("SelectAttack", 0f, 0.5f);
        ataack = false;
       
    }
    private void Update()
    {
        nice = tags.enemyattack;

        if(tags.changeno)
        CheckState();
            Move();


        if (tags.EnemyDead)
        {
            anime.SetBool("death", true);
        }
   if(enemycheck==state.attack)

            attack2();
  }

    void Move()
    {
        if (tags.check >= 1.5f )

        {

            if (ec.navagent.isStopped == false)
            {
                x = Mathf.MoveTowards(x, 01, 3 * Time.deltaTime);
                y = Mathf.MoveTowards(y, 0, 6 * Time.deltaTime);
                anime.SetFloat(z, x);
                anime.SetFloat("float jump", y);
            }
            else
            {
                x = Mathf.MoveTowards(x, 0, 3 * Time.deltaTime);
                y = Mathf.MoveTowards(y, 0, 6 * Time.deltaTime);
                anime.SetFloat(z, x);
                anime.SetFloat("float jump", y);
            }
        }
         
    }

    void attack2()
    {

        if (ec.navagent.isStopped)
        {
            if (tags.enemyattack < 3)
            {
                h1 = 0;
                if (tags.enemyattack == 0)
                {
                    anime.SetTrigger("Punch");
                    anime.ResetTrigger("roundhouse kick");
                    anime.ResetTrigger("uppercut");
                    anime.ResetTrigger("block");
                }


                if (tags.enemyattack == 1)
                {
                    anime.SetTrigger("roundhouse kick");
                    anime.ResetTrigger("uppercut");
                    anime.ResetTrigger("Punch");
                    anime.ResetTrigger("block");
                }
                if (tags.enemyattack == 2)
                {
                    anime.SetTrigger("uppercut");
                    anime.ResetTrigger("Punch");
                    anime.ResetTrigger("roundhouse kick");
                    anime.ResetTrigger("block");
                }
                if((tags.enemyattack==3 || tags.enemyattack==4) && anime1.GetCurrentAnimatorStateInfo(0).IsName("roundhousekick") && anime1.GetCurrentAnimatorStateInfo(0).IsName("Hurricane Kick") && anime.GetCurrentAnimatorStateInfo(0).IsName("uppercut")&& anime1.GetCurrentAnimatorStateInfo(0).IsName("uppercut") &&anime1.GetCurrentAnimatorStateInfo(0).IsName("hook punch"))
                {
                    anime.SetTrigger("block");
                    anime.ResetTrigger("uppercut");
                    anime.ResetTrigger("Punch");
                    anime.ResetTrigger("roundhouse kick");
                }
            }
            else if(tags.enemyattack>4 && h1<2f )
            {
                h1 = h1 + Time.deltaTime;
                anime.ResetTrigger("uppercut");
                anime.ResetTrigger("Punch");
                anime.ResetTrigger("roundhouse kick");
                anime.ResetTrigger("block");


            }
            else
            {
                anime.ResetTrigger("uppercut");
                anime.ResetTrigger("Punch");
                anime.ResetTrigger("roundhouse kick");
            }

            
        }
         
    }

  void CheckState()
    {
        if (tags.check < 1.5f)
        {
            x = Mathf.MoveTowards(x, 0, 3 * Time.deltaTime);
            y = Mathf.MoveTowards(y, 0, 6 * Time.deltaTime);
            anime.SetFloat(z, x);
            anime.SetFloat("float jump", y);
            enemycheck = state.attack;
        }
        else if(tags.check>1.5f )
        {
            x = Mathf.MoveTowards(x, 01, 3 * Time.deltaTime);
            y = Mathf.MoveTowards(y, 0, 6 * Time.deltaTime);
            anime.SetFloat(z, x);
            anime.SetFloat("float jump", y);
            enemycheck = state.walk;
        }
    }
    
    void SelectAttack()
    {
        tags.enemyattack = Random.Range(0, 9);
    }

    IEnumerator Wait()
    {
        anime.ResetTrigger("Punch");
        yield return new WaitForSeconds(2f);
        
    }
}
