using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Don't need override
/**
 * * Inheritance testing.
*/
public class ExplosionButtonController : ButtonController
{
    private GameObject rage_fire;

    // private void Start(){
    //     // rage_fire = FindgameObject("rage_fire");
    //     // do some addative function
    // }

    public override void ActiveButton(){
        flashEffect.SetActive(true);
        particleController.Play();
        HideFlashEffect(1f);

        isActive = true;
        inactive.SetActive(false);
        Enable();
    }

    IEnumerator HideFlashEffect(float time){
        yield return new WaitForSeconds(time);
        flashEffect.SetActive(false);
    }
}
