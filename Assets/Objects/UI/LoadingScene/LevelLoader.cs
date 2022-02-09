using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadScene(string _sceneName){
        StartCoroutine(LoadAsynchronously(_sceneName));
    }

    IEnumerator LoadAsynchronously(string _sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName: _sceneName);
        while (!operation.isDone){
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}
