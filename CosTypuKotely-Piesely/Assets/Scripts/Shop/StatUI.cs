using UnityEngine;

[System.Serializable]
public class StatUI
{
    [SerializeField]
    private string statName;
    [SerializeField]
    private TMPro.TMP_Text statValueText;

    public Float CacheStat { get; private set; }

    public void Init()
    {
        Float stat = Player.Instance.PlayerStats.GetStat(statName);
        CacheStat = stat;
        SetText(CacheStat.Value);
        CacheStat.OnValueChanged += SetText;
    }

    public void DetachEvents()
    {
        CacheStat.OnValueChanged -= SetText;
    }

    public void SetText(float value)
    {
        statValueText.SetText(value.ToString());
    }

}
