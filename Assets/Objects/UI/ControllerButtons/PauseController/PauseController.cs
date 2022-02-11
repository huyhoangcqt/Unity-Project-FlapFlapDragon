using UnityEngine;
using System.Collections;

public class PauseController : Singleton<PauseController>
{
    public static bool isPaused;

    private void Start() {
        isPaused = false;
    }

    public void PauseGame(){
        // isPaused = !isPaused;
        isPaused = true;
        AudioListener.pause = isPaused;
    }

    public void ResumeGame(){
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
