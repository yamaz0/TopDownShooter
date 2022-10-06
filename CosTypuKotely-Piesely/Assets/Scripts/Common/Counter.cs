using UnityEngine;

public class Counter
{
    public int Value { get; private set; }
    public int MaxValue { get; private set; }
    public int MinValue { get; private set; }

    public Counter(int value, int min = 0, int max = int.MaxValue)
    {
        Value = value;
        MinValue = min;
        MaxValue = max;
    }

    public void Set(int v)
    {
        Value = Mathf.Clamp(v, MinValue, MaxValue);
    }

    public void SetMin(int v)
    {
        MinValue = v;
    }

    public void SetMax(int v)
    {
        MaxValue = v;
    }

    public void Increase()
    {
        Value++;
        if (Value > MaxValue)
            Value = MinValue;
    }

    public void Decrease()
    {
        Value--;
        if (Value < MinValue)
            Value = MaxValue;
    }
}