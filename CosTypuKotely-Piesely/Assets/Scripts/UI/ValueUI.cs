using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text valueText;
    [SerializeField]
    private TMPro.TMP_Text nameText;

    public void SetValue(float value)
    {
        valueText.SetText(value.ToString());
    }

    public void SetName(string text)
    {
        nameText.SetText(text);
    }
}
