using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : Singleton<SkillManager>
{
    private ButtonController[] btnControllers;

    public void Start(){
        btnControllers = new ButtonController[transform.childCount];
        for (int i = 0; i < btnControllers.Length; i++){
            btnControllers[i] = transform.GetChild(i).GetComponent<ButtonController>();
        }
    }

    public void BannedAll(float time){
        foreach (ButtonController btnController in btnControllers){
            btnController.BannedOn(time);
        }  
    }
}
