using UnityEngine;
using Zenject;

[System.Serializable]
public class Cost
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private int level;

    public int Level { get => level; private set => level = value; }

    public void Init(AnimationCurve c, int startLvl = 0)
    {
        curve = c;
        Level = startLvl;
    }

    public float GetValue()
    {
        return curve.Evaluate(Level);
    }

    public float GetValue(int targetLevel)
    {
        return curve.Evaluate(targetLevel);
    }
    public bool TryBuy()
    {
        float cost = GetValue();
        Float playerGold = Player.Instance.PlayerStats.Cash;

        if (playerGold.Value < cost)
            return false;

        playerGold.AddValue(-cost);
        Level++;

        return true;
    }
}
