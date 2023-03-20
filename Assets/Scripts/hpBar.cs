using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    public Slider playerBar;

    public void SetMaxHealth(float health)
    {
        playerBar.maxValue = health;
        playerBar.value = health;
    }

    public void SetHealth(float health)
    {
        playerBar.value = health;
    }
}
