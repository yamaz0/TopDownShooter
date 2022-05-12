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
        SetMaxHp(Player.Instance.PlayerStats.Hp.Value);
        SetHp(Player.Instance.PlayerStats.MaxHp.Value);

        Player.Instance.PlayerStats.Hp.OnValueChanged += SetHp;
        Player.Instance.PlayerStats.MaxHp.OnValueChanged += SetMaxHp;
    }

    private void OnDisable()
    {
        Player.Instance.PlayerStats.Hp.OnValueChanged -= SetHp;
        Player.Instance.PlayerStats.MaxHp.OnValueChanged -= SetMaxHp;
    }

    public void SetMaxHp(float value)
    {
        slider.maxValue = value;
    }

    public void SetHp(float value)
    {
        slider.value = value;
    }
}
