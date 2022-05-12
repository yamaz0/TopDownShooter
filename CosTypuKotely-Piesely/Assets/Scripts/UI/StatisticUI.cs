using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text text;

    private void Start()
    {
        Player.Instance.PlayerStats.Gold.OnValueChanged += SetValue;
    }
    private void OnDisable()
    {

        Player.Instance.PlayerStats.Gold.OnValueChanged -= SetValue;
    }
    public void SetValue(float value)
    {
        text.SetText(value.ToString());
    }
}
