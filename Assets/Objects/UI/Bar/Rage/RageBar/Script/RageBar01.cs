using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RageBar01 : MonoBehaviour
{
    private float maxRage, crrRage;
    private Image fillImage;

    void Start(){
        fillImage = transform.Find("fill").GetComponent<Image>();
    }

    private float lerpTimer = 0f;
    private float chipSpeed = 0.5f;
    private Color red = new Color((float)0.8018868, (float)0.01134743, (float)0.07315017, 1f);
    void Update(){
        float fill = fillImage.fillAmount;
        float fraction = crrRage / maxRage;
        lerpTimer += Time.deltaTime;
        float percentComplete = lerpTimer / chipSpeed;
        percentComplete *= percentComplete;
        if (fill < fraction){ // Recovery
            fillImage.fillAmount = Mathf.Lerp(fill, fraction, percentComplete);
        }
        if (fill > fraction){ // TakeDamage
            fillImage.fillAmount = fraction;
        }
    }

    public void SetMaxRage(float amount){
        maxRage = amount;
        crrRage = amount;
    }

    public void ConsumeRage(float amount){
        lerpTimer = 0f;
        crrRage -= amount;
        if (crrRage < 0){
            crrRage = 0;
        }
        // print("Current HP: " + crrRage.ToString("N0"));
    }

    public void RestoreRage(float amount){
        lerpTimer = 0f;
        crrRage += amount;
        if (crrRage > maxRage){
            crrRage = maxRage;
        }
        // print("Current HP: " + crrRage.ToString("N0"));
    }
}
