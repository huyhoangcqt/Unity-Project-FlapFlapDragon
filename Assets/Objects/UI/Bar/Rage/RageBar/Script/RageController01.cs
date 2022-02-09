using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageController01 : Singleton<RageController01>
{
    [SerializeField] private RageBar01 rageBar;
    [SerializeField] int crrRage, maxRage;

    void Start() {
        rageBar.SetMaxRage((float)maxRage);
        rageBar.SetCurrentRage((float)crrRage);
    }

    // private void Update() {
    //     if (Input.GetMouseButtonDown(0)){
    //         rageBar.ConsumeRage(Random.Range(2, 20));
    //     };
    //     if (Input.GetMouseButtonDown(1)){
    //         rageBar.RestoreRage(Random.Range(2,20));
    //     }
    // }

    internal void RestoreRage(float rage){
        rageBar.RestoreRage(rage);
    }

    internal void ConsumeRage(float rage){
        rageBar.ConsumeRage(rage);
    }

    public bool CheckingRage(int rage){
        return rageBar.CheckingRage(rage);
    }
}
