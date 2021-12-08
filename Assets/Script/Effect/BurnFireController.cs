﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnFireController : MonoBehaviour
{

    private float duration = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BurnTiming());
    }

    public void SetDuration(float duration){
        this.duration = duration;
    }

    IEnumerator BurnTiming(){
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
