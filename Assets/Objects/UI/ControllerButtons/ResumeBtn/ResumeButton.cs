using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject transparentPanel, pausePanel;

    public void OnButtonClicked(){
        PauseController.instance.ResumeGame();
        transparentPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
