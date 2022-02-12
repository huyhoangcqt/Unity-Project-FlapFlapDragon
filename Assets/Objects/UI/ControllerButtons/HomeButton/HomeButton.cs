using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private string homeSceneName;
    public void TriggerButton(){
        GameController.inputEnabled = true;
        SceneManager.LoadScene(sceneName: homeSceneName);
    }
}
