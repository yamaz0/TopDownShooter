using TMPro;
using UnityEngine;
using Zenject;

[System.Serializable]
public class RefillStatUI : ShopAttributeUI
{
    [SerializeField]
    private TMPro.TMP_Text statValueText;
    [SerializeField]
    private string statName;
    [SerializeField]
    private string maxStatName;
    [SerializeField]
    private float value = 1;

    [Inject]
    private Player PlayerInstance { get; set; }
    public Float CacheStat { get; private set; }
    public Float CacheMaxStat { get; private set; }

    public TMP_Text StatValueText { get => statValueText; set => statValueText = value; }

    public override void Init()
    {
        CacheStat = PlayerInstance.PlayerStats.GetStat(statName);
        CacheMaxStat = Player.Instance.PlayerStats.GetStat(maxStatName);

        SetText(CacheStat.Value);
        StatNameText.SetText(statName);
        CacheStat.OnValueChanged += SetText;
        CacheMaxStat.OnValueChanged += SetValueText;
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnButtonClick);
    }

    public override void DetachEvents()
    {
        CacheStat.OnValueChanged -= SetText;
        CacheMaxStat.OnValueChanged -= SetValueText;
        Button.onClick.RemoveAllListeners();
    }
    public override void OnButtonClick()
    {
        if (Cost.TryBuy())
            CacheStat.SetValue(CacheMaxStat.Value);
        else
        {
            int cash = (int)Player.Instance.PlayerStats.Cash.Value;

            if (Cost.TryBuy(cash))
                CacheStat.AddValue(cash);
        }
    }

    public void SetValueText(float value)
    {
        float difference = value - CacheStat.Value;
        Cost.SetLevel((int)difference);

        CostValueText.SetText(Cost.Value.ToString());
    }

    public override void SetText(float value)
    {
        SetValueText(CacheMaxStat.Value);
        StatValueText.SetText(value.ToString());
    }
}
