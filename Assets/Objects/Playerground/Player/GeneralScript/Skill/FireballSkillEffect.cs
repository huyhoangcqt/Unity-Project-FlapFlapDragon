using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkillEffect : MonoBehaviour
{
    
    [SerializeField] private GameObject fireball, bulletSrc;
    private PlayerController playerController;
    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();    
        playerController = GetComponent<PlayerController>();
    }

    public void FireballStart(){
        anim.SetBool("isSkill1Active", true);
        playerController.DisableAttack();
        ShootFireball();
    }

    private void ShootFireball(){
        GameObject fireball_instance = Instantiate(fireball, bulletSrc.transform.position, Quaternion.identity);
    }

    public void FireballEnd(){
        playerController.EnableAttack();
        anim.SetBool("isSkill1Active", false);
    }
}
