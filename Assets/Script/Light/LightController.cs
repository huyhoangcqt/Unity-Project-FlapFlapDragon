using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : Singleton<LightController>
{
    private static GameObject worldLight;
    private static Light2D globalLight;
    private static float intensityBk;

    private void Start(){
        worldLight = GameObject.Find("WorldLight");
        // Light2D[] light2Ds = FindObjectsOfType<Light2D>();
        globalLight = worldLight.GetComponent<Light2D>();
        intensityBk = globalLight.intensity;
    }

    public static void Darken(){
        globalLight.intensity = 0.1f;
    }

    public static void Recover(){
        globalLight.intensity = intensityBk;
    }
}
