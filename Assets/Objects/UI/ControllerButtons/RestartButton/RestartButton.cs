using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnButtonClicked(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneName: currentScene.name);
    }
}
