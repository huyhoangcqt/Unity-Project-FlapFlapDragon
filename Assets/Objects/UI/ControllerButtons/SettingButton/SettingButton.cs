using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    private void Update() {
        if (PauseController.isPaused || !GameController.inputEnabled){
            GetComponent<Button>().enabled = false;
        }
        else {
            GetComponent<Button>().enabled = true;
        }
    }
}
