using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private string homeSceneName;
    public void TriggerButton(){
        SceneManager.LoadScene(sceneName: homeSceneName);
    }
}
