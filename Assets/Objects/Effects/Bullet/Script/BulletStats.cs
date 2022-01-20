using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    [SerializeField] private int _dmgPercent, _burnDmgPercent, _duration, _speed;
    [SerializeField] private string _element;
    public int dmgPercent{
        get{ return _dmgPercent; }
        private set{ _dmgPercent = value; }
    }
    public int burnDmgPercent{
        get{ return _burnDmgPercent; }
        private set{ _burnDmgPercent = value; }
    }
    public int duration{
        get{ return _duration; }
        private set{ _duration = value; }
    }
    public int speed{
        get{ return _speed; }
        private set{ _speed = value; }
    }
    public string element{
        get{ return _element; }
        private set{ _element = value; }
    }

    private int _dmg = 0, _burnDps = 0;
    public int dmg{
        get{ return _dmg; }
        private set{ _dmg = value; }
    }
    public int burnDps{
        get{ return _burnDps; }
        private set { _burnDps = value;}
    }

    public void Awake(){
        if (dmgPercent < 0){
            dmgPercent = 0;
        }
        if (dmgPercent == 0){
            dmgPercent = 100;
        }
        if (burnDmgPercent < 0){
            burnDmgPercent = 0;
        }
        if (burnDmgPercent == 0){
            burnDmgPercent = 10;
        }
        if (duration < 0){
            duration = 0;
        }
        if (duration == 0){
            duration = 2;
        }
        if (speed < 0){
            speed = 0;
        }
        if (speed == 0){
            speed = 10;
        }
        if (element == null){
            element = "Neutral";
        }
    }

    public void Start() {
        GameObject player = GameObject.Find("BabyDragon");
        if (player == null){
            Debug.LogError("Player not found");
        } else {
            int dmg = player.GetComponent<Stats>().dmg;
            AssignPlayerDmg(dmg);
        }
    }

    //Call in Normal skill (Controll by UI script);
    public void AssignPlayerDmg(int playerDmg){
        _dmg = playerDmg * dmgPercent / 100;
        if (dmg == 0){
            dmg = 1;
        }
        _burnDps = playerDmg * burnDmgPercent / 100;
        if (burnDps == 0){
            burnDps = 1;
        }
    }
}
