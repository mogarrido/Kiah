using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
   [SerializeField]
    Slider slider;

    public void SetValue(int health) => slider.value = health;
}
