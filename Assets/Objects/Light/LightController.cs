using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : Singleton<LightController>
{
    private GameObject worldLight;
    private Light2D globalLight;
    private float tempIntensity;
    [SerializeField]private GlowGrassController grassController;

    private void Start(){
        worldLight = GameObject.Find("WorldLight");
        // Light2D[] light2Ds = FindObjectsOfType<Light2D>();
        globalLight = worldLight.GetComponent<Light2D>();
        tempIntensity = globalLight.intensity;
    }

    public void Darken(){
        tempIntensity = globalLight.intensity;
        FadeIntensity(globalLight, 0.1f, 1f);
        grassController.Darken();
    }

    public void Recover(){
        FadeIntensity(globalLight, tempIntensity, 2f);
        grassController.Recover();
    }

    public void FadeIntensity(Light2D light, float des, float duration){
        StartCoroutine(FadeIntensityIEnumerator(light, des, duration));
    }

    IEnumerator FadeIntensityIEnumerator(Light2D light, float des, float duration){
        float deltaTime = 0.2f;
        float crr = light.intensity;
        float deltaIntensity = (des - crr) /duration * deltaTime;
        while (duration > 0.01f){
            yield return new WaitForSeconds(deltaTime);
            duration -= deltaTime;
            crr = light.intensity;
            light.intensity = crr + deltaIntensity;
        }
    }
}
