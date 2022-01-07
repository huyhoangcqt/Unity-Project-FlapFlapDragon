using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSkillManager : MonoBehaviour
{
    [SerializeField]private DashSkillEffect skillEffect;
    [SerializeField]private ButtonControl button;
    [SerializeField]private PlayerController playerController;
    [SerializeField]private float durationTime, cooldownTime;
    private SkillManager skillManager;
    public void Start(){
        skillManager = gameObject.GetComponent<SkillManager>();
    }

    public void Update(){
        if (Input.GetMouseButtonDown(0)){
            CooldownStart();
        }
    }

    private IEnumerator DashDuration(){
        yield return new WaitForSeconds(durationTime - 2f);
        playerController.DashMovementLastMove();
        yield return new WaitForSeconds(1f);
        DashSkillEnd();
    }

    private void DashSkillEnd(){
        skillEffect.DashEffectEnd();
        playerController.DashMovementOff();
    }

    private void DashSkillStart(){
        playerController.status = PlayerStatus.Invincible;
        skillEffect.DashEffectStart();
        playerController.PreDashMovement();
        button.BannedOn(durationTime);
    }

    private IEnumerator WaitingPreDashSkill(){
        yield return new WaitForSeconds(1f);
        playerController.DashMovementOn();
    }

    public void OnButtonClick(){
        //Skill Effect
        DashSkillStart();
        StartCoroutine(WaitingPreDashSkill());
        StartCoroutine(DashDuration());
        //Cooldown
        CooldownStart();
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
