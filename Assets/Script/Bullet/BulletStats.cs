using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public int dmgPercent, burnDmgPercent, duration = 2;
    public string element = "Neutral";
    private int dmg = 0, burnDps = 0;

    public int speed;

    public void Start(){
    }
    // Start is called before the first frame update

    //Call in Normal skill (Controll by UI script);
    public void AssignPlayerDmg(int playerDmg){
        dmg = playerDmg * dmgPercent / 100;
        burnDps = playerDmg * burnDmgPercent / 100;
    }

    public int GetDmg(){
        return dmg;
    }

    public int GetBurnDps(){
        return burnDps;
    }
}
