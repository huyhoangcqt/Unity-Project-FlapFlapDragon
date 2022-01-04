using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillManager : MonoBehaviour
{
    [SerializeField]private DashSkillEffect skillEffect;
    [SerializeField]private DashButton button;
    [SerializeField]private float coolDownTime;
    [SerializeField]private PlayerController playerController;

    private IEnumerator StartCoolDownTime(){
        yield return new WaitForSeconds(coolDownTime - 2f);
        playerController.DashMovementLastMove();
        yield return new WaitForSeconds(1f);
        DashSkillEnd();
    }

    private void PreDashSkillStart(){
        playerController.status = PlayerStatus.Invincible;
        skillEffect.DashEffectStart();
        button.Disable();
        playerController.PreDashMovement();
    }

    private IEnumerator WaitingPreDashSkill(){
        yield return new WaitForSeconds(1f);
        DashSkillStart();
    }

    public void OnButtonClick(){
        //Sound
        PreDashSkillStart();
        StartCoroutine(WaitingPreDashSkill());
        StartCoroutine(StartCoolDownTime());
    }

    private void DashSkillStart(){
        playerController.DashMovementOn();
    }

    private void DashSkillEnd(){
        skillEffect.DashEffectEnd();
        playerController.DashMovementOff();
        button.Enable();
    }
}
