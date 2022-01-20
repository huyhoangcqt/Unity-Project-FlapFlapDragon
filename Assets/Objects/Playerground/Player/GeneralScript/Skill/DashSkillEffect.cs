using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillEffect : MonoBehaviour
{
    private Rigidbody2D rgbd2D;
    private Animator anim;
    [SerializeField] private GameObject trail1, trail2;
    [SerializeField] private float dashForce;
    private float tempGravityScale;
    private PlayerController pController;
    private GameObject trail1_instance, trail2_instance;

    void Start(){
        rgbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pController = GetComponent<PlayerController>();
    }

    public void DashEffectStart(){
        anim.SetBool("isSkill2Active", true);
        MovementOn();

        trail1_instance = Instantiate(trail1, transform.position, Quaternion.identity);
        trail2_instance = Instantiate(trail2, transform.position, Quaternion.identity);
        trail2_instance.transform.parent = pController.transform;
    }

    private void MovementOn(){
        tempGravityScale = rgbd2D.gravityScale;
        rgbd2D.gravityScale = 0f;
        rgbd2D.velocity = Vector2.zero;
        pController.DisableAttack();
        pController.DisableInputGetting();
        rgbd2D.AddForce(new Vector2(dashForce, 0));
    }

    public void DashEffectEnd(){
        anim.SetBool("isSkill2Active", false);
        MovementEnd();
        Destroy(trail1_instance);
        Destroy(trail2_instance);
    }

    private void MovementEnd(){
        rgbd2D.velocity = Vector2.zero;
        rgbd2D.gravityScale = tempGravityScale;
        pController.EnableAttack();
        pController.EnabledInputGetting();
    }
}
