using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject transparentPanel, pausePanel;

    public void OnButtonClicked(){
        transparentPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
