using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private void Start()
    {
        Player.Instance.Hp.OnValueChanged += SetHP;
    }

    private void OnDisable()
    {
        Player.Instance.Hp.OnValueChanged -= SetHP;
    }

    public void SetHP(float value)
    {
        slider.value = value;
    }
}
