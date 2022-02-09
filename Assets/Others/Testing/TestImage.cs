using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TriggerActive(){
        //print("on click");
        gameObject.SetActive(Trigger(gameObject.activeSelf));
    }

    public bool Trigger(bool value){
        //print("Value " + (!value).ToString());
        return !value;
    }
}
