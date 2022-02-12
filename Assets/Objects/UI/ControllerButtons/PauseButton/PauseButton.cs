using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // private Sprite playStatusImg, pauseStatusImg;
    [SerializeField] private GameObject pausedPanel, transparentPanel;

    public void OnButtonClicked(){
        PauseController.instance.PauseGame();
        pausedPanel.SetActive(true);
        transparentPanel.SetActive(true);
    }

    private void Update() {
        if (PauseController.isPaused || !GameController.inputEnabled){
            gameObject.GetComponent<Button>().enabled = false;
        }
        else {
            gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
