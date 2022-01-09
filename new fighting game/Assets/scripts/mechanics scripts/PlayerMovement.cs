using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float check;
    animationcontroller animationscript;
    public Transform enemy;
    public float x;
    public enemycontroller cc;
    void Start()
    {
      
        animationscript = gameObject.GetComponent<animationcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.ISCollided == false && tags.MoveOnWall == true)
            moment();
        if (cc.ISCollided && !tags.PlayerDead)
        {

            animationscript.x = Mathf.MoveTowards(animationscript.x, 0, 6 * Time.deltaTime);
        }
        Jump();
    }

    void moment()
    {
        if (animationscript.isJumping && !isAnim("roundhousekick")&& !isAnim("hook punch") && !isAnim("Hurricane Kick") && !isAnim("uppercut")&&animationscript.y==0)
        {
            if (animationscript.x < 1 && Input.GetKey(KeyCode.A))
            {

                if (check > -1)
                    check = check - 3f * Time.deltaTime;

                transform.Translate(-Vector3.forward * 0.8f * Time.deltaTime);
            }
            else if (animationscript.x > 1 && Input.GetKey(KeyCode.D))
            {

                if (check < 1)
                {
                    check = check + 3f * Time.deltaTime;
                }
                transform.Translate(Vector3.forward * check * Time.deltaTime * 0.8f);
            }
            else
            {
                transform.Translate(Vector3.forward * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 0.8f);
                check = 0;
            }
        }

        if (animationscript.y > 0)
        {
            
            animationscript.x = 0;
        }

    }

    void Jump()
    {

        animationscript.isGrounded = Physics.CheckSphere(animationscript.Jump_Check.position, 0.05f, animationscript.Ground);

        if (animationscript.isGrounded && animationscript.vel.y < 0)
        {
            
        }
       

        if (Input.GetButtonDown("Jump") && animationscript.isGrounded)
        {
            animationscript.anime.SetBool("jump", true);

            StartCoroutine("StopJumpMovement");
        }
        else
        {
            animationscript.anime.SetBool("jump", false);
        }

        if (animationscript.isGrounded == false)
        {
          
        }
    }

    IEnumerator StopJumpMovement()
    {
        animationscript.isJumping = false;
        yield return new WaitForSeconds(0.25f);
       animationscript.isJumping = true;
        yield return new WaitForSeconds(animationscript.clip.length - 0.86f);
       animationscript.isJumping = false;
        yield return new WaitForSeconds(0.4f);
        animationscript.isJumping = true;
    }

    bool isAnim(string animname)
    {
        return animationscript.anime.GetCurrentAnimatorStateInfo(0).IsName(animname);
    }


}
