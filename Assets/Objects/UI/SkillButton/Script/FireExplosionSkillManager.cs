using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosionSkillManager : MonoBehaviour
{
    [SerializeField]private ExplosionSkillEffect skillEffect;
    [SerializeField]private ButtonController button;
    [SerializeField]private PlayerController playerController;
    [SerializeField]private float durationTime, cooldownTime;
    private SkillManager skillManager;

    public void Start(){
        skillManager = gameObject.GetComponent<SkillManager>();
    }

    private IEnumerator ExplosionDuration(){
        yield return new WaitForSeconds(4f);
        skillEffect.CloseMouth();
        yield return new WaitForSeconds(durationTime - 4f);
        ExplosionSkillEnd();
    }

    private void ExplosionSkillEnd(){
        skillEffect.ExplosionEffectEnd();
        playerController.ExplosionMovementOff();
        playerController.status = PlayerStatus.Normal;
        LightController.instance.Recover();
    }

    private void ExplosionSkillStart(){
        button.isActive = false;
        playerController.status = PlayerStatus.Invincible;
        playerController.Disappear();
        playerController.PreExplosionMovement();
        SkillManager.instance.BannedAll(durationTime);
        LightController.instance.Darken();
    }

    private IEnumerator WaitingPreExplosionSkill(){
        yield return new WaitForSeconds(1f);
        playerController.Appear();
        skillEffect.ExplosionEffectStart();
    }

    public void OnButtonClick(){
        ExplosionSkillStart();
        StartCoroutine(WaitingPreExplosionSkill());
        StartCoroutine(ExplosionDuration());
        
        ButtonCooldownStart();
        ButtonBannedOnStart();
    }

    private void ButtonBannedOnStart(){
        button.BannedOn(durationTime);
    }

    private void ButtonCooldownStart(){
        button.CooldownStart(cooldownTime);
    }
}
