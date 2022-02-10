using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool isPaused;

    private  void Awake() {
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
}
