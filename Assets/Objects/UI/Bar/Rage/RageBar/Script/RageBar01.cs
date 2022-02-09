using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RageBar01 : MonoBehaviour
{
    private float maxRage, crrRage;
    private Image fillImage;
    public Gradient gradient;
    public GameObject[] rageFires;

    void Awake(){
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
        fillImage.color = gradient.Evaluate(fillImage.fillAmount);
        if (fill == 1){
            RageFullEffect();
        }
        else {
            DisableRageFullEffect();
        }
    }

    public void RageFullEffect(){
        if (rageFires.Length > 0){
            for (int i = 0; i < rageFires.Length; i++){
                rageFires[i].SetActive(true);
            }
        }
    }
    public void DisableRageFullEffect(){
        if (rageFires.Length > 0){
            for (int i = 0; i < rageFires.Length; i++){
                rageFires[i].SetActive(false);
            }
        }
    }

    public void SetMaxRage(float amount){
        maxRage = amount;
    }
    public void SetCurrentRage(float amount){
        crrRage = amount;
        fillImage.color = gradient.Evaluate(crrRage / maxRage);
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

    public bool CheckingRage(int rage){
        if (crrRage >= rage){
            return true;
        }
        return false;
    }
}
