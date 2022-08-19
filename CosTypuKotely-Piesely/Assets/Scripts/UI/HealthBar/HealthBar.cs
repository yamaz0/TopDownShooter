using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [Inject]
    private Player PlayerInstance { get; set; }

    private void Start()
    {
        SetHp(PlayerInstance.PlayerStats.Hp.Value);

        PlayerInstance.PlayerStats.Hp.OnValueChanged += SetHp;
    }

    private void OnDisable()
    {
        PlayerInstance.PlayerStats.Hp.OnValueChanged -= SetHp;
    }

    public void SetHp(float value)
    {
        float hpPercentageValue = PlayerInstance.PlayerStats.Hp.Value / PlayerInstance.PlayerStats.MaxHp.Value;
        slider.value = hpPercentageValue;
    }
}
