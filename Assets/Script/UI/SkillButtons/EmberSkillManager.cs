using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EmberSkillManager : Singleton<EmberSkillManager>
{
    [SerializeField] private EmberSkillEffect emberEffect;
    [SerializeField] private ButtonController button;
    [SerializeField] private float cooldownTime;


    // Start is called before the first frame update
    public void Process(Touch touch){   
        if (button.gameObject.GetComponent<Button>().enabled) {
            emberEffect.Process(touch);
            OnEmberStart();
        }
        button.isEnoughEnergy = true;
    }

    public void OnEmberStart(){
        emberEffect.OnEmberStart();
        button.isActive = false;
        CooldownStart();
    }

    public void OnEmberEnd(){
        emberEffect.OnEmberEnd();
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

    internal void CooldownEnd(){
        button.CooldownEffectEnd();
    }

    private void CooldownStart(){
        button.CooldownEffectStart(cooldownTime);
        StartCoroutine(StartCooldown(cooldownTime));
    }
}
