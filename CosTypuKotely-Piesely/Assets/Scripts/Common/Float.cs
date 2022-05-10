using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float
{
    [SerializeField]
    private float value;

    public float Value { get => value; private set => this.value = value; }

    event System.Action<float> OnValueChanged = delegate { };

    public void AddValue(float value)
    {
        SetValue(Value + value);
    }

    public void SetValue(float value)
    {
        Value = value;
        OnValueChanged(Value);
    }
}
