using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBarFill : MonoBehaviour
{
    private Animator anim;
    private  Image image;
    private Color backupColor;
    private Color effectColor = new Color32(200, 0, 0, 255);
    private int eventLoop = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
        image = GetComponent<Image>();
    }

    public void BackupColor(){
        backupColor = image.color;
    }

    public void ChangeColor(){
        image.color = effectColor;
    }

    public void OnEventCompleted(){
        eventLoop++;
        if (eventLoop == 2){
            anim.SetBool("onRageUp", false);
            eventLoop = 0;
        }
        else {
            image.color = backupColor;
        }
    }
}
