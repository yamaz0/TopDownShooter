using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ValueUI : TextUI
{
    [SerializeField]
    private TMPro.TMP_Text valueText;

    public void SetValue(float value)
    {
        valueText.SetText(value.ToString());
    }
}
