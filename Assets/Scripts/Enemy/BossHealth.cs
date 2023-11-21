using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] Health healthBoss;
    
    Slider healthSlider;

    float healthMax;
    float fillValue;
    private void Awake()
    {
        if (healthBoss != null)
        {
            healthMax = healthBoss.health;
        }
        healthSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (healthBoss == null) return;

        fillValue = healthBoss.health / healthMax;
        healthSlider.value = fillValue;
    }
}
