using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar01 : MonoBehaviour
{
    private float maxHp, crrHp;
    private Image fillImage, fillBgImage;

    void Start(){
        fillImage = transform.Find("fill").GetComponent<Image>();
        fillBgImage = transform.Find("fill_bg").GetComponent<Image>();
    }

    private float lerpTimer = 0f;
    private float chipSpeed = 0.5f;
    private Color red = new Color((float)0.8018868, (float)0.01134743, (float)0.07315017, 1f);
    void Update(){
        float fill = fillImage.fillAmount;
        float fillBg = fillBgImage.fillAmount;
        float fraction = crrHp / maxHp;
        lerpTimer += Time.deltaTime;
        float percentComplete = lerpTimer / chipSpeed;
        percentComplete *= percentComplete;
        if (fill < fraction){ // Recovery
            fillBgImage.color = Color.green;
            fillBgImage.fillAmount = Mathf.Lerp(fillBg, fraction, percentComplete);
            fillImage.fillAmount = Mathf.Lerp(fill, fraction, percentComplete);
        }
        if (fillBg > fraction){ // TakeDamage
            fillImage.fillAmount = fraction;
            fillBgImage.color = red;
            fillBgImage.fillAmount = Mathf.Lerp(fillBg, fraction, percentComplete);
        }
    }

    public void SetMaxHealth(float amount){
        maxHp = amount;
        crrHp = amount;
    }

    public void TakeDamage(float amount){
        lerpTimer = 0f;
        crrHp -= amount;
        if (crrHp < 0){
            crrHp = 0;
        }
        // print("Current HP: " + crrHp.ToString("N0"));
    }

    public void RestoreHealth(float amount){
        lerpTimer = 0f;
        crrHp += amount;
        if (crrHp > maxHp){
            crrHp = maxHp;
        }
        // print("Current HP: " + crrHp.ToString("N0"));
    }
}
