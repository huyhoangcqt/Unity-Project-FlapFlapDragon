using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // public Text valueText;

    private float crrHP = 1, maxHP = 1;

    public void SetMaxHealth(float maxHP){
        this.maxHP = maxHP;
        slider.maxValue = maxHP;
        this.crrHP = this.maxHP;
        slider.value = this.crrHP;
        fill.color = gradient.Evaluate(1f);
        // valueText.text = crrHP.ToString() + "/" + maxHP.ToString();
    }

    public void SetCurrentHealth(float currentHP){
        crrHP = currentHP;
        slider.value = crrHP;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        // valueText.text = crrHP.ToString() + "/" + maxHP.ToString();
    }
}
