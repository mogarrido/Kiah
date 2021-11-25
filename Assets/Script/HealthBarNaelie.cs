using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarNaelie : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    Boss boss;

    public void SetValue(int health) => slider.value = health;
}
