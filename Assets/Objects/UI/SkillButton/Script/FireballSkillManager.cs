using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireballSkillManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private FireballSkillEffect fireballEffect;
    [SerializeField] private ButtonController button;
    [SerializeField] private float cooldownTime, durationTime;

    private void Start() {
        if (durationTime == 0){
            durationTime = 0.25f;
        }
        if (cooldownTime == 0){
            cooldownTime = 5f;
        }
    }

    public void OnButtonClick(){
        FireballStart();
        CooldownStart();
    }

    public void FireballStart(){
        playerController.FireballStart();
        StartCoroutine(FireballDuration(durationTime));
    }

    IEnumerator FireballDuration(float durationTime){
        yield return new WaitForSeconds(0.1f);
        fireballEffect.FireballStart();
        yield return new WaitForSeconds(durationTime - 0.1f);
        FireballEnd();
    }

    public void FireballEnd(){
        playerController.FireballEnd();
        fireballEffect.FireballEnd();
    }

    /**
     * * Cooldown
    */
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
