using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text healthText;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        UpdateHealthText(health);
    }

    public void  SetHealth(int health)
    {
        slider.value = health;
        UpdateHealthText(health);
    }

    void UpdateHealthText(int health)
    {
        healthText.text = health.ToString();
    }
}
