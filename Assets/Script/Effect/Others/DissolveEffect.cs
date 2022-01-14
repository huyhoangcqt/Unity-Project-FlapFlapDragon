using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    private Material material;
    public float duration = 2f;
    private bool isDissolve  = false;
    private float timeLoad = 0f, completedTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        isDissolve = false;
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Fade", 0);
    }

    void Update(){
        if (OnLoadComplete()){
            isDissolve = true;
        }
        if (isDissolve){
            StartCoroutine(Fade());
        };
        timeLoad += Time.deltaTime;
    }

    //TO DO: update later. checking when the scene is load completed
    private bool OnLoadComplete(){
        if (timeLoad >= completedTime){
            return true;
        }
        return false;
    }

    IEnumerator Fade(){
        
        float deltaTime = 0.1f;
        float multi = duration / deltaTime;
        float maxFade = 1f;
        float deltaFade = maxFade/ multi; // range of Fade from 0 to 1;
        float fade = material.GetFloat("_Fade");
        while (fade < maxFade){
            yield return new WaitForSeconds(deltaTime);
            fade += deltaFade;
            if (fade > maxFade){
                fade = maxFade;
            }
            material.SetFloat("_Fade", fade);
        }
        isDissolve = false;
    }
}
