using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FireballSkillManager : MonoBehaviour
{
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

    public void OnButtonClick()
	{
		Debug.Log("OnButtonClick");
		if (!PauseController.isPaused){ 
            FireballStart();
            CooldownStart();

            //Xóa bộ đệm vị trí con trỏ. Tránh cho khi thao tác, UIEventSystem lại tưởng click lên Element này.
			EventSystem.current.SetSelectedGameObject(null);
		}
    }

    public void FireballStart(){
        Debug.Log("FireballStart");
        StartCoroutine(FireballDuration(durationTime));
    }

    IEnumerator FireballDuration(float durationTime){
        fireballEffect.FireballStart();
        button.ConsumeEnergy();
        yield return new WaitForSeconds(durationTime);
        FireballEnd();
    }

    public void FireballEnd(){
        fireballEffect.FireballEnd();
    }

    private void CooldownStart(){
        button.CooldownStart(cooldownTime);
    }
}
