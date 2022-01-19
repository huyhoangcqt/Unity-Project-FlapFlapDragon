using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkillEffect : MonoBehaviour
{
    
    [SerializeField] private GameObject fireball, bulletSrc;
    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();    
    }

    public void FireballStart(){
        anim.SetBool("isSkill1Active", true);
        ShootFireball();
    }

    private void ShootFireball(){
        GameObject fireball_instance = Instantiate(fireball, bulletSrc.transform.position, Quaternion.identity);
    }

    public void FireballEnd(){
        anim.SetBool("isSkill1Active", false);
    }
}
