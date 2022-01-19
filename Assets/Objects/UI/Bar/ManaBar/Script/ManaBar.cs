using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // public Text valueText;

    private float crrMP = 100, maxMP = 100;

    public void SetMaxMana(float maxMP){
        this.maxMP = maxMP;
        slider.maxValue = maxMP;
        this.crrMP = this.maxMP;
        slider.value = this.crrMP;
        fill.color = gradient.Evaluate(1f);
        // valueText.text = crrMP.ToString() + "/" + maxMP.ToString();
    }

    public void SetCurrentMana(float currentMP){
        crrMP = currentMP;
        slider.value = crrMP;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        // valueText.text = crrMP.ToString() + "/" + maxMP.ToString();
    }
}
