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
    public bool CheckingMana(int value){
        return manaBar.CheckingMana(value);
    }

    internal void RestoreMana(float mana){
        manaBar.RestoreMana(mana);
    }

    internal void ConsumeMana(float mana){
        manaBar.ConsumeMana(mana);
    }
}
