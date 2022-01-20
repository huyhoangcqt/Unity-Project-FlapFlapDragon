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

    private void CooldownStart(){
        button.CooldownStart(cooldownTime);
    }
}
