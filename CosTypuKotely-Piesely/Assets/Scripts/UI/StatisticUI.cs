using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StatisticUI : ValueUI
{
    [SerializeField]
    private string statName;

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

}
