using UnityEngine;

[System.Serializable]
public class StatUI: MonoBehaviour
{
    [SerializeField]
    private string statName;
    [SerializeField]
    private TMPro.TMP_Text statValueText;
    [SerializeField]
    private TMPro.TMP_Text statNameText;

    public Float CacheStat { get; private set; }

    public void Init()
    {
        Float stat = Player.Instance.PlayerStats.GetStat(statName);
        CacheStat = stat;
        SetText(CacheStat.Value);
        statNameText.SetText(statName);
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
