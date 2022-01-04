using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillEffect : MonoBehaviour
{

    private Rigidbody2D rgbd2D;
    private Animator anim;
    private GameObject dash;
    void Start(){
        rgbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dash = transform.Find("Dash").gameObject;
        if (dash == null){
            Debug.LogError("Dash is not exist");
        }
    }
    public void DashEffectStart(){
        print("Dash effect start");
        anim.SetBool("isSkill2Active", true);
        dash.SetActive(true);
    }

    public void DashEffectEnd(){
        anim.SetBool("isSkill2Active", false);
        dash.SetActive(false);
    }
}
