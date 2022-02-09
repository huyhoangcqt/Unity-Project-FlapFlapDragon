using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // [SerializeField] private string _sceneName;
    [SerializeField] private Slider slider;
    private void Start() {
        if (SceneManager.GetActiveScene().name == "LoadingScene"){
            LoadScene("MainScene");
        }
    }
    public void LoadScene(string _sceneName){
        StartCoroutine(LoadAsynchronously(_sceneName));
    }

    IEnumerator LoadAsynchronously(string _sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName: _sceneName);
        while (!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
