using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient Gradient;
    public Image fill;
    public void setHealth(float health)
    {
        slider.value = health;
        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }
}
