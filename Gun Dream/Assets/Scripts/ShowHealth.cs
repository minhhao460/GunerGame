using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient Health_Player;
    private GameObject Cam;
    private void Start()
    {

    }

    private void LateUpdate()
    {
        if (Cam == null)
            Cam = GameObject.FindGameObjectWithTag("MainCamera");
        if (Cam != null)
            transform.LookAt(gameObject.transform.position + Cam.transform.forward);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetColor(Color color)
    {
        fill.color = color;
    }

    public void SetHealthGradient()
    {
        fill.color = Health_Player.Evaluate(slider.normalizedValue);
    }

    public void SetAll(float MaxH, float H, Color color)
    {
        SetMaxHealth(MaxH);
        SetHealth(H);
        SetColor(color);
    }

    // Sử dụng cho Player
    public void SetAll(float MaxH, float H, bool isPlayer)
    {
        SetMaxHealth(MaxH);
        SetHealth(H);
        SetHealthGradient();
    }
}
