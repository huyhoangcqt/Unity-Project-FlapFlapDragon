using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private MapOption mapOption;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] GameObject loadingSreen;

    public void ButtonClicked(){
        int current = mapOption.current;

        if (current == 0){
            loadingSreen.SetActive(true);
            levelLoader.LoadScene("SeceneMap1");
        }
        else {
            mapOption.ActiveNotiicationText();
        }
    }
}
