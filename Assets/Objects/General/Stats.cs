using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _mp;
    [SerializeField] private int _dmg;
    [SerializeField] private int _spe;

    protected virtual void Initialize(){

    }
    public void Awake(){
        Initialize();
    }

    public int hp{
        get {
            return _hp;
        }
        set { _hp = value; }
    }
    public int mp{
        get {
            return _mp;
        }
        set { _mp = value;}
    }
    public int dmg{
        get {
            return _dmg;
        }
        set { _dmg = value;}
    }
    public int spe{
        get {
            return _spe;
        }
        set { _spe = value;}
    }
}
