using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/**
 * * Normal attack
*/
public class EmberSkillManager : Singleton<EmberSkillManager>
{
    private EmberSkillEffect emberEffect;
    [SerializeField] private float duration; //Default time: 0.15 = duration time of animation Attack
    private float attackTime;

    private void Start() {
        emberEffect = GetComponent<EmberSkillEffect>();
        if (duration == 0f){
            duration = 0.15f;
        }
        attackTime = 0f;
    }

    // Start is called before the first frame update
    public void Process(Touch touch){  
        if (touch.phase == TouchPhase.Began){
            emberEffect.Process(touch);
            if (attackTime <= 0f){                
                OnEmberStart();
            }
            attackTime += duration;
        }
    }

    public void OnEmberStart(){
        emberEffect.OnEmberStart();
    }

    private void Update(){
        if (attackTime <= 0f){
            OnEmberEnd();
        }
        else {
            attackTime -= Time.deltaTime;
        }
    }

    public void OnEmberEnd(){
        emberEffect.OnEmberEnd();
    }
}
