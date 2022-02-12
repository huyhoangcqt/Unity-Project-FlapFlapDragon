using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnButtonClicked(){
        GameController.inputEnabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
