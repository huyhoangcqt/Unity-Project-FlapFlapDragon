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

    public void ExplosionEffectEnd(){
        anim.SetBool("isSkill3Active", false);
        Destroy(explo_instance);
    }
}
