﻿using UnityEngine;
using System.Collections;

public class PauseController : Singleton<PauseController>
{
    public static bool isPaused = false;
    protected override void Awake() {
        isPaused = false;
        instance = this;   
    }

    public void PauseGame(){
        // isPaused = !isPaused;
        GameController.inputEnabled = false;
        isPaused = true;
        AudioListener.pause = isPaused;
    }

    public void ResumeGame(){
        GameController.inputEnabled = true;
        isPaused = false;
        AudioListener.pause = isPaused;
    }

    private void Update() {
        if (!isPaused){
            Time.timeScale = 1f;
        }
        else {
            Time.timeScale = 0f;
        }
    }

    public void SlowDown(float value, int speed){
        StartCoroutine(SlowDownIE(value, speed));
    }

    IEnumerator SlowDownIE(float value, int speed){
        while (Time.timeScale > value){
            yield return new WaitForSeconds(0.1f/speed);
            Time.timeScale = Mathf.Clamp01(Time.timeScale - 0.1f);
        }
    }
}
