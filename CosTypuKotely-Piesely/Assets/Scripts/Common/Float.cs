using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cost
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private int level;

    public void Init(AnimationCurve c, int startLvl = 0)
    {
        curve = c;
        level = startLvl;
    }

    public float GetValue()
    {
        return curve.Evaluate(level);
    }

    public float GetValue(int targetLevel)
    {
        return curve.Evaluate(targetLevel);
    }
    public bool TryBuy()
    {
        float cost = GetValue();
        Float playerGold = Player.Instance.PlayerStats.Gold;

        if (playerGold.Value < cost)
            return false;

        playerGold.AddValue(-cost);
        level++;

        return true;
    }
}

[System.Serializable]
public class Float
{
    [SerializeField]
    private float value;

    public float Value { get => value; private set => this.value = value; }

    public event System.Action<float> OnValueChanged = delegate { };

    public Float(float initValue)
    {
        Value = initValue;
    }

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
