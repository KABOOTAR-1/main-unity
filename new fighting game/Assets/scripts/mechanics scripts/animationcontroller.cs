using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontroller : MonoBehaviour
{
   public Animator anime;
    int z;
    public float x=0;
    public float y;
   public float xheck = 0;
    public Transform Jump_Check;
    public LayerMask Ground;
    public Vector3 vel;

    public bool isGrounded;
    public AnimationClip clip;
   public bool isJumping=true;
    

    public enemycontroller cc;

    void Start()
    {
        anime = GetComponent<Animator>();
       z=Animator.StringToHash("velocity");
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {

        transform.position = new Vector3(1.15860f, transform.position.y, transform.position.z);
    }
    void Update() 
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        

        var fixclips= anime.GetCurrentAnimatorStateInfo(0);
        
         
        movementanimation();


        transform.position = new Vector3(1.15860f, transform.position.y, transform.position.z);
   
       

       if (!anime.GetBool("kick") && !tags.PlayerDead)
        Attack();

      }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isAnim("roundhousekick") && !isAnim("uppercut") && !isAnim("block"))
        {
            anime.SetTrigger("Punch");
            anime.ResetTrigger("roundhouse kick");
            anime.ResetTrigger("uppercut");
            anime.ResetTrigger("block");
        }
       

        if (Input.GetKeyDown(KeyCode.Z) && !isAnim("uppercut") && !isAnim("Punch") && !isAnim("block"))
        {
            anime.SetTrigger("roundhouse kick");
            anime.ResetTrigger("uppercut");
            anime.ResetTrigger("block");
            anime.ResetTrigger("Punch");
        }
        if (Input.GetKeyDown(KeyCode.C) && !isAnim("roundhouse kick") && !isAnim("Punch") && !isAnim("block"))
        {
            anime.SetTrigger("uppercut");
            anime.ResetTrigger("block");
            anime.ResetTrigger("Punch");
            anime.ResetTrigger("roundhouse kick");

        }
        if (Input.GetKeyDown(KeyCode.B) && !isAnim("uppercut") && !isAnim("Punch") && !isAnim("roundhousekick"))
        {
            anime.SetTrigger("block");
            anime.ResetTrigger("roundhouse kick");
            anime.ResetTrigger("uppercut");
            anime.ResetTrigger("Punch");
        }
       
    }
void movementanimation()

    {
        float h = 0;
        

       
      

        

        if (y > 0)
        {
            x = 0;
        }
            
        if (h <= (clip.length + 0.5f) && !isGrounded)
        {
            h += Time.deltaTime;
            x = 1;
        }
        if(h>clip.length+0.5f)
        {
            h = 0;
        }

        if (Input.GetKey(KeyCode.A) && !anime.GetBool("kick") )
        {
            x = Mathf.MoveTowards(x, -1, 6 * Time.deltaTime);
            y = Mathf.MoveTowards(y, 0, 3 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && !anime.GetBool("kick")&& !cc.ISCollided)
        {
            
                x = Mathf.MoveTowards(x, 1, 6 * Time.deltaTime);
                y = Mathf.MoveTowards(y, 0, 3 * Time.deltaTime);
            
        }
       
       
        else
        {
            x = Mathf.MoveTowards(x, 0, 3 * Time.deltaTime);

            if (!anime.GetBool("kick") )
                {
               
                y = Mathf.MoveTowards(y, 0, 4 * Time.deltaTime);

                }
                anime.SetBool("kick", false);
            
        }
        anime.SetFloat(z, x);
       
     
    }

    bool isAnim(string animname)
    {
        return anime.GetCurrentAnimatorStateInfo(0).IsName(animname);
    }



}
