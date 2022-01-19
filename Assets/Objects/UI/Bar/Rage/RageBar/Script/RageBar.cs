using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // public Text valueText;

    private float crrRage = 0, maxRage = 100; //100%

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    public void SetMaxRage(float maxRage){
        this.maxRage = maxRage;
        slider.maxValue = maxRage;
        this.crrRage = this.maxRage;
        slider.value = this.crrRage;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetCurrentRage(float currentRage){
        crrRage = currentRage;
        slider.value = crrRage;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
