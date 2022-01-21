using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    private Stats stats;
    protected override void Initialize(){
        if (hp < 0){ hp = 0;}
        if (hp == 0){
            hp = 200;
        }
        if (mp < 0){ mp = 0;}
        if (mp == 0){
            mp = 100;
        }
        if (dmg < 0){ dmg = 0;}
        if (dmg == 0){
            dmg = 10;
        }
        if (spe < 0){ spe = 0;}
        if (spe == 0){
            spe = 10;
        }
        if (manaRecovery < 0){ manaRecovery = 0;}
        if (manaRecovery == 0){
            manaRecovery = 1;
        }
    }
}
