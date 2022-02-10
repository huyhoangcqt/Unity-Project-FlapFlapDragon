using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashSkillManager : MonoBehaviour
{
    [SerializeField]private DashSkillEffect skillEffect;
    [SerializeField]private ButtonController button;
    [SerializeField]private float durationTime, cooldownTime;
    [SerializeField]private SkillManager skillManager;
    private bool isExecuting = false;
    private float tempDurationTime;

    public void OnButtonClick(){
        if (!PauseController.isPaused){
            DashSkillStart();
            ButtonCoolDownStart();
            ButtonBannedOn();
        }
    }

    private void Update(){
        if (tempDurationTime > 0){
            tempDurationTime -= Time.deltaTime;
        }
        else {
            if (isExecuting){
                DashSkillEnd();
                isExecuting = false;
            }
        }
    }

    private void DashSkillStart(){
        isExecuting = true;
        tempDurationTime = durationTime;
        skillEffect.DashEffectStart();
        button.ConsumeEnergy();
    }

    private void DashSkillEnd(){
        skillEffect.DashEffectEnd();
    }

    private void ButtonCoolDownStart(){    
        button.CooldownStart(cooldownTime);
    }

    private void ButtonBannedOn(){
        skillManager.BannedAll(durationTime);
    }
}
