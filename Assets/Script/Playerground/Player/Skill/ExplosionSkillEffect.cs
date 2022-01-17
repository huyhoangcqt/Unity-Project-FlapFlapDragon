using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSkillEffect : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject explosionEffect;

    void Start(){
        anim = GetComponent<Animator>();
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
    }
}
