using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketItemManager : MonoBehaviour
{
    [SerializeField]private RocketItemEffect itemEffect;
    [SerializeField]private float durationTime, cooldownTime;
    private SkillManager skillManager;
    
    public void Start(){
        skillManager = gameObject.GetComponent<SkillManager>();
    }

    private IEnumerator RocketItemDuration(){
        yield return new WaitForSeconds(durationTime - 1f);
        itemEffect.RocketItemMovementLastMove();
        yield return new WaitForSeconds(1f);
        RocketItemEnd();
    }

    private void RocketItemEnd(){
        itemEffect.RocketItemEffectEnd();
    }

    private void RocketItemStart(){
        itemEffect.RocketItemEffectStart();
        SkillManager.instance.BannedAll(durationTime);
    }

    private IEnumerator WaitingPreRocketItem(){
        yield return new WaitForSeconds(1f);
        itemEffect.RocketItemMovementOn();
    }

    public void OnRocketItemPickedUp(){
        //Skill Effect
        RocketItemStart();
        StartCoroutine(WaitingPreRocketItem());
        StartCoroutine(RocketItemDuration());
    }
}
