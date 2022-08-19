using UnityEngine;
using Zenject;

[System.Serializable]
public class Cost
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private int level;

    [Inject]
    private Player PlayerInstance { get; set; }
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
        Float playerGold = PlayerInstance.PlayerStats.Cash;

        if (playerGold.Value < cost)
            return false;

        playerGold.AddValue(-cost);
        level++;

        return true;
    }
}
