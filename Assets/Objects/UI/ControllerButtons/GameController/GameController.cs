using System.Collections;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private GameObject player, gameoverPanel, transparentPanel;

    public void GameOver(){
        StartCoroutine(GameOverIE());
    }

    IEnumerator GameOverIE(){
        player.GetComponent<Animator>().SetBool("isDie", true);
        LightController.instance.Darken();
        PauseController.instance.SlowDown(0.2f, 2);
        yield return new WaitForSeconds(1f);
        PauseController.instance.PauseGame();
        transparentPanel.SetActive(true);
        gameoverPanel.SetActive(true);
    }

    public void GameResume(){
        PauseController.instance.ResumeGame();
    }
}
