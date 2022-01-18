using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/**
 * * Normal attack
*/
public class EmberSkillManager : Singleton<EmberSkillManager>
{
    private EmberSkillEffect emberEffect;
    [SerializeField] private float duration; //Approximately 0.15 second

    private void Start() {
        emberEffect = GetComponent<EmberSkillEffect>();
        if (duration == 0){
            duration = 0.15f;
        }
    }

    // Start is called before the first frame update
    public void Process(Touch touch){  
        if (touch.phase == TouchPhase.Began){
            emberEffect.Process(touch);
            OnEmberStart();
        }
    }

    public void OnEmberStart(){
        emberEffect.OnEmberStart();
        StartCoroutine(EmberDuration(duration));
    }

    public void OnEmberEnd(){
        emberEffect.OnEmberEnd();
    }

    IEnumerator EmberDuration(float durationTime){
        yield return new WaitForSeconds(durationTime);
        OnEmberEnd();
    }
}
