using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManaController01 : MonoBehaviour
{
    [SerializeField] private ManaBar01 manaBar;
    [SerializeField] int mp, mpRecovery;

    void Start() {
        manaBar.SetMaxMana((float)mp);
        manaBar.mpRecovery = (float)mpRecovery;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)){
            manaBar.ConsumeMana(Random.Range(2, 20));
        };
        if (Input.GetMouseButtonDown(1)){
            manaBar.RestoreMana(Random.Range(2,20));
        }
    }
}
