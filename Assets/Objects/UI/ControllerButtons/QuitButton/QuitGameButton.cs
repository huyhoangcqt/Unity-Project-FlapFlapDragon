using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    [SerializeField] private GameObject quitGamePanel;

    public void OnTriggerButton(){
        quitGamePanel.SetActive(true);
    }

    public void CancelQuitGame(){
        quitGamePanel.SetActive(false);
    }

    public void ConfirmQuitGame(){
        Application.Quit();
    }
}
