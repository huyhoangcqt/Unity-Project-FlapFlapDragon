using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar01 : MonoBehaviour
{
    private float maxMp, crrMp, _mpRecovery;
    public float mpRecovery{
        get { return _mpRecovery;}
        set { _mpRecovery = value;}
    }
    private Image fillImage;
    private RawImage bubbleRawImage;
    // private RectTransform lineTransform, barTransform;

    void Start(){   
        // barTransform = GetComponent<RectTransform>();
        fillImage = transform.Find("fill").GetComponent<Image>();        
        bubbleRawImage = fillImage.transform.Find("bubble").GetComponent<RawImage>();
        // lineTransform = fillImage.transform.Find("line").GetComponent<RectTransform>();
    }

    private float lerpTimer = 0f;
    private float chipSpeed = 0.5f;
    private Color red = new Color((float)0.8018868, (float)0.01134743, (float)0.07315017, 1f);
    void Update(){
        //mana recovery
        if (crrMp < maxMp){
            crrMp += mpRecovery * Time.deltaTime;
        }
        //Update bar effect
        float fill = fillImage.fillAmount;
        float fraction = crrMp / maxMp;
        lerpTimer += Time.deltaTime;
        float percentComplete = lerpTimer / chipSpeed;
        percentComplete *= percentComplete;
        Rect uvRect = bubbleRawImage.uvRect;
        if (fill < fraction){ // Restore or Recovery
            fillImage.fillAmount = Mathf.Lerp(fill, fraction, percentComplete);
            uvRect.x -= 0.2f * Time.deltaTime;
            bubbleRawImage.uvRect = uvRect;
        }
        if (fill > fraction){ // Consume
            fillImage.fillAmount = fraction;
            uvRect.x += 0.2f * fraction * 100 * Time.deltaTime;
            bubbleRawImage.uvRect = uvRect;
        }
        
        // lineTransform.gameObject.SetActive(crrMp < maxMp);
        // lineTransform.anchoredPosition = new Vector2(fillImage.fillAmount * (barTransform.sizeDelta.x) -5, 0);
    }

    public void SetMaxMana(float amount){
        maxMp = amount;
        crrMp = amount;
    }

    public void ConsumeMana(float amount){
        lerpTimer = 0f;
        crrMp -= amount;
        if (crrMp < 0){
            crrMp = 0;
        }
        print("Current MP: " + crrMp.ToString("N0"));
    }

    public void RestoreMana(float amount){
        lerpTimer = 0f;
        crrMp += amount;
        if (crrMp > maxMp){
            crrMp = maxMp;
        }
        print("Current MP: " + crrMp.ToString("N0"));
    }

    public bool CheckingMana(int value){
        if (crrMp >= value){
            return true;
        }
        return false;
    }
}
