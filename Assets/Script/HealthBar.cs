using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    Einho player;

    public void SetValue(int health) => slider.value = health;
}
