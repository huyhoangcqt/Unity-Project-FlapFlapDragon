using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkillManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private FireballSkillEffect fireballEffect;
    [SerializeField] private ButtonController button;
    [SerializeField] private float durationTime;  //Default is 0.5f; Approximately 0.500001 second
    
    private void Start() {
        if (durationTime == 0){
            durationTime = 0.5f;
        }
    }

    public void OnButtonClick(){
        FireballStart();
    }

    public void FireballStart(){
        playerController.FireballStart();
        fireballEffect.FireballStart();
        StartCoroutine(FireballDuration(durationTime));
    }

    IEnumerator FireballDuration(float durationTime){
        yield return new WaitForSeconds(durationTime);
        FireballEnd();
    }

    public void FireballEnd(){
        playerController.FireballEnd();
        fireballEffect.FireballEnd();
    }
}
