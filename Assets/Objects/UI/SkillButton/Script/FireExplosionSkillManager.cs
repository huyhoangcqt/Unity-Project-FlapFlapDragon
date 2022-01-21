using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosionSkillManager : MonoBehaviour
{
    [SerializeField]private ExplosionSkillEffect skillEffect;
    [SerializeField]private ButtonController button;
    [SerializeField]private float durationTime, cooldownTime;
    private SkillManager skillManager;

    public void Start(){
        skillManager = gameObject.GetComponent<SkillManager>();
    }

    private IEnumerator ExecutingExplosionSkill(float prepareTime){
        yield return new WaitForSeconds(prepareTime);
        skillEffect.ExplosionEffectStart();
        yield return new WaitForSeconds(4f);
        skillEffect.CloseMouth();
        yield return new WaitForSeconds(durationTime - 4f);
        ExplosionSkillEnd();
    }

    private void ExplosionSkillEnd(){
        skillEffect.ExplosionEffectEnd();
        LightController.instance.Recover();
    }

    private void ExplosionSkillStart(){
        float prepareTime = 1f;
        PrepareExplosionSkill(prepareTime);
        StartCoroutine(ExecutingExplosionSkill(prepareTime));
    }

    private void PrepareExplosionSkill(float time){
        LightController.instance.Darken();
        skillEffect.PrepareExplosionSkill(time);
        button.ConsumeEnergy();
    }

    public void OnButtonClick(){
        ExplosionSkillStart();        
        ButtonCooldownStart();
        ButtonBannedOnStart();
    }

    private void ButtonBannedOnStart(){
        button.BannedOn(durationTime);
        SkillManager.instance.BannedAll(durationTime);
    }

    private void ButtonCooldownStart(){
        button.CooldownStart(cooldownTime);
    }
}
