using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageController01 : MonoBehaviour
{
    [SerializeField] private RageBar01 rageBar;
    [SerializeField] int rage;

    void Start() {
        rageBar.SetMaxRage((float)rage);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)){
            rageBar.ConsumeRage(Random.Range(2, 20));
        };
        if (Input.GetMouseButtonDown(1)){
            rageBar.RestoreRage(Random.Range(2,20));
        }
    }
}
