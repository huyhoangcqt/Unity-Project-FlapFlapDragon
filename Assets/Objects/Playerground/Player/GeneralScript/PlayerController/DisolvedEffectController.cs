using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolvedEffectController : MonoBehaviour
{
    private List<DissolveEffect> disEffList;
    [SerializeField] private float duration;

    private void Start() {
        DissolveEffect[] dissolveEffects;
        dissolveEffects = transform.GetComponentsInChildren<DissolveEffect>();
        foreach (DissolveEffect effElement in dissolveEffects){
            // print(effElement.gameObject.name);
            if (effElement.duration != duration){
                effElement.duration = duration;
            }
        }
    }

}
