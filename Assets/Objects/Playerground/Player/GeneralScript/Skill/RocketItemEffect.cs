using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketItemEffect : MonoBehaviour
{
    // private PlayerStatus status;
    private Rigidbody2D rgbd2D;
    private Animator anim;
    private GameObject dash;
    [SerializeField] private float dashForce;
    private float tempGravityScale;
    void Start(){
        rgbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dash = transform.Find("RocketItem").gameObject;
        if (dash == null){
            Debug.LogError("RocketItem is not exist");
        }
    }
    public void RocketItemEffectStart(){
        // status = PlayerStatus.Invincible;
        PreRocketItemMovement();
        anim.SetBool("isSkill2Active", true);
        dash.SetActive(true);
    }

    public void RocketItemEffectEnd(){
        anim.SetBool("isSkill2Active", false);
        dash.SetActive(false);
        RocketItemMovementOff();
        // status = PlayerStatus.Normal;
    }

    /*
    * * Rocket movement control function
    */
    public void PreRocketItemMovement(){
        // DisableAttack();
        // DisableInputGetting();
        rgbd2D.velocity = Vector3.zero;
        tempGravityScale = rgbd2D.gravityScale;
        rgbd2D.gravityScale = 0f;

        rgbd2D.AddForce(new Vector2(50, 0f));
    }

    public void RocketItemMovementOn(){
        rgbd2D.AddForce(new Vector2(dashForce, 0f));
    }

    public void RocketItemMovementOff(){
        // EnableAttack();
        // EnabledInputGetting();
        rgbd2D.gravityScale = tempGravityScale;
    }

     public void RocketItemMovementLastMove(){
        rgbd2D.AddForce(new Vector2 (-dashForce, 0f));
    }
}
