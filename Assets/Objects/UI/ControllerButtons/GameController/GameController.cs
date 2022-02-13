using System.Collections;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private GameObject player, gameoverPanel, transparentPanel;
    public static bool inputEnabled = true;

    protected override void Awake() {
        instance = this;
        inputEnabled = true;
    }

    public void GameOver(){
        StartCoroutine(GameOverIE());
    }

    IEnumerator GameOverIE(){
        player.GetComponent<Animator>().SetBool("isDie", true);
        player.GetComponent<PlayerController>().DisableInputGetting();
        inputEnabled = false;
        LightController.instance.Darken();
        PauseController.instance.SlowDown(0.2f, 2);
        yield return new WaitForSeconds(1f);
        PauseController.instance.PauseGame();
        transparentPanel.SetActive(true);
        gameoverPanel.SetActive(true);
    }
}
