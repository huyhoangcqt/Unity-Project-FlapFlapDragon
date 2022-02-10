using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // private Sprite playStatusImg, pauseStatusImg;
    [SerializeField] private GameObject pausedPanel, transparentPanel;
    private bool cachePaused;

    private void Awake() {
        // playStatusImg = Resources.Load<Sprite>("PauseButton/play_status");
        // pauseStatusImg = Resources.Load<Sprite>("PauseButton/pause_status");
    }

    // public void TriggerButton(){
    //     if (!PauseController.isPaused){
    //         gameObject.GetComponent<Image>().sprite = pauseStatusImg;
    //     }
    //     else {
    //         gameObject.GetComponent<Image>().sprite = playStatusImg;
    //     }
    // }

    public void OnButtonClicked(){
        pausedPanel.SetActive(true);
        transparentPanel.SetActive(true);
    }

    private void Update() {
        if (PauseController.isPaused){
            gameObject.GetComponent<Button>().enabled = false;
        }
        else {
            gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
