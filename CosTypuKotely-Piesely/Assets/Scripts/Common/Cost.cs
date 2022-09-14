using UnityEngine;
using Zenject;

[System.Serializable]
public class Cost
{
    [SerializeField]
    private float value;
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private int level;

    public float Value { get => value; set => this.value = value; }
    public AnimationCurve Curve { get => curve; set => curve = value; }
    public int Level { get => level; private set => level = value; }

    public void Init(AnimationCurve c, int startLvl = 0)
    {
        Curve = c;
        Level = startLvl;
    }

    public void SetLevel(int lvl)
    {
        Level = lvl;
        CalculateNewValue();
    }

    public float GetCostAtLevel(int lvl)
    {
        return Curve.Evaluate(lvl);
    }

    private void CalculateNewValue()
    {
        Value = Curve.Evaluate(Level);
    }
    public bool CanBuy()
    {
        float cost = Value;
        float playerGold = Player.Instance.PlayerStats.Cash.Value;

        return playerGold >= cost;
    }

    public bool TryBuy()
    {
        if (CanBuy() == true)
        {
            Player.Instance.PlayerStats.Cash.AddValue(-Value);
            return true;
        }
        return false;
    }
}
