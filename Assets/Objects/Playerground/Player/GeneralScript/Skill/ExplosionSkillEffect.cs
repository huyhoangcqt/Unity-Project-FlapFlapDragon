using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSkillEffect : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject explosionEffect;
    private PlayerController pController;
    private Rigidbody2D rgbd2D;

    void Start(){
        anim = GetComponent<Animator>();
        pController = GetComponent<PlayerController>(); 
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    private GameObject explo_instance;
    public void ExplosionEffectStart(){
        anim.SetBool("isSkill3Active", true);
        explo_instance = Instantiate(explosionEffect, Vector3.zero, Quaternion.identity);
    }

    public void CloseMouth(){
        anim.SetBool("isSkill3Completed", true);
    }

    public void ExplosionEffectEnd(){
        anim.SetBool("isSkill3Active", false);
        anim.SetBool("isSkill3Completed", false);
        Destroy(explo_instance, 2f);
        pController.EnableAttack();
        pController.EnabledInputGetting();
        rgbd2D.gravityScale = tempGravityScale;
        pController.status = PlayerStatus.Normal;
    }

    public void PrepareExplosionSkill(float time){
        anim.SetBool("isIdle", false);
        pController.status = PlayerStatus.Invincible;
        pController.DisableAttack();
        pController.DisableInputGetting();

        StartCoroutine(TransformPlayerPositionIE(time));
    }

    private float tempGravityScale;
    [SerializeField]private GameObject flashEffect;

    private IEnumerator TransformPlayerPositionIE(float time){
        //Effect disapear
        Vector3 tempLocalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        GameObject flashInstance = Instantiate(flashEffect, transform.position, Quaternion.identity );
        Destroy(flashInstance, 2f);
        //translate position
        rgbd2D.velocity = Vector3.zero;
        tempGravityScale = rgbd2D.gravityScale;
        rgbd2D.gravityScale = 0f;
        print(transform.tag);
        print(transform.position.x);
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        yield return new WaitForSeconds(1f);
        //Effect appear
        transform.localScale = tempLocalScale;
        GameObject flashInstance_2 = Instantiate(flashEffect, transform.position, Quaternion.identity );
        Destroy(flashInstance_2, 2f);
    }
}
