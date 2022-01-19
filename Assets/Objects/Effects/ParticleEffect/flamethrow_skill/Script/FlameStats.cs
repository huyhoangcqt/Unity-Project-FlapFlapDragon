using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameStats : MonoBehaviour
{
    public float dmgPercent;
    public float burnDmgPercent;

    private float dmg;
    private float burnDmg;
    // Start is called before the first frame update
    void Start()
    { 
    }

    public void AssignPlayerDmg(int playerDmg){
        dmg = playerDmg * dmgPercent / 100;
        burnDmg = playerDmg * burnDmgPercent / 100;
    }

    public float GetBurnDmg(){
        return burnDmg;
    }

    public float GetDmg(){
        return dmg;
    }
}
