using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Condition{
    public float rage;
} 
public class FireExplosionSkillManager : MonoBehaviour
{
    [SerializeField]private Condition condition;
    [SerializeField]private ExplosionSkillEffect skillEffect;
    [SerializeField]private ButtonController button;
    [SerializeField]private PlayerController playerController;
    [SerializeField]private float durationTime, cooldownTime;
    private SkillManager skillManager;
    public void Start(){
        skillManager = gameObject.GetComponent<SkillManager>();
    }

    private IEnumerator ExplosionDuration(){
        yield return new WaitForSeconds(durationTime);
        ExplosionSkillEnd();
    }

    private void ExplosionSkillEnd(){
        skillEffect.ExplosionEffectEnd();
        playerController.ExplosionMovementOff();
        playerController.status = PlayerStatus.Normal;
        LightController.Recover();
    }

    private void ExplosionSkillStart(){
        button.isActive = false;
        playerController.status = PlayerStatus.Invincible;
        playerController.PreExplosionMovement();
        button.BannedOn(durationTime);
        LightController.Darken();
    }

    private IEnumerator WaitingPreExplosionSkill(){
        yield return new WaitForSeconds(1f);
        skillEffect.ExplosionEffectStart();
    }

    public void OnButtonClick(){
        button.isEnoughEnergy = CheckingRagePoint();
        //Skill Effect
        ExplosionSkillStart();
        StartCoroutine(WaitingPreExplosionSkill());
        StartCoroutine(ExplosionDuration());
        //Cooldown
        CooldownStart();
    }

    private bool CheckingRagePoint(){
        return true;
    }

    private  IEnumerator StartCooldown(float time){
        button.UpdateCooldownText(time, "N0");
        while (time > 1f){
            yield return new WaitForSeconds(1f);
            time -= 1f;
            button.UpdateCooldownText(time, "N0");
        }
        while (time > 0f){
            yield return new WaitForSeconds(0.1f);
            time -= 0.1f;
            button.UpdateCooldownText(time, "N1");
        }
        CooldownEnd();
    }

    private void CooldownStart(){
        button.CooldownEffectStart(cooldownTime);
        StartCoroutine(StartCooldown(cooldownTime));
    }

    internal void CooldownEnd(){
        button.CooldownEffectEnd();
    }
}
