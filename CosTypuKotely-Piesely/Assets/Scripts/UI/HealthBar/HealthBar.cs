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
        SetHp(Player.Instance.PlayerStats.Hp.Value);

        Player.Instance.PlayerStats.Hp.OnValueChanged += SetHp;
    }

    private void OnDisable()
    {
        Player.Instance.PlayerStats.Hp.OnValueChanged -= SetHp;
    }

    public void SetHp(float value)
    {
        float hpPercentageValue = Player.Instance.PlayerStats.Hp.Value / Player.Instance.PlayerStats.MaxHp.Value;
        slider.value = hpPercentageValue;
    }
}
