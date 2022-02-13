using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private GameObject transparentPanel, settingPanel;
    private bool isTrigger;
    private int cache;
    //isTrigger = true => open setting Panel. Else: close setting Panel;

    private void Awake() {
        isTrigger = false;
        cache = 0;
    }

    public void TriggerButton(){
        isTrigger = !isTrigger;
        cache = 0;
    }

    private void Update() {
        if (isTrigger && cache == 0){
            PauseController.instance.PauseGame();
            transparentPanel.SetActive(true);
            settingPanel.SetActive(true);
            cache = 1;
        }
        else if (!isTrigger && cache == 0){
            PauseController.instance.ResumeGame();
            transparentPanel.SetActive(false);
            settingPanel.SetActive(false);
            cache = 1;
        }

        if (PauseController.isPaused || !GameController.inputEnabled){
            GetComponent<Button>().enabled = false;
        }
        else {
            GetComponent<Button>().enabled = true;
        }
    }
}
