using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StatisticUI : MonoBehaviour
{
    [SerializeField]
    private string statName;
    [SerializeField]
    private TMPro.TMP_Text text;

    [Inject]
    private Player PlayerInstance { get; set; }

    private void Start()
    {
        PlayerInstance.PlayerStats.GetStat(statName).OnValueChanged += SetValue;
    }

    private void OnDisable()
    {
        PlayerInstance.PlayerStats.GetStat(statName).OnValueChanged -= SetValue;
    }

    public void SetValue(float value)
    {
        text.SetText(value.ToString());
    }
}
