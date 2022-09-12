using TMPro;
using UnityEngine;
using Zenject;
[System.Serializable]
public class StatUI : ShopAttributeUI
{
    [SerializeField]
    private TMPro.TMP_Text statValueText;
    [SerializeField]
    private string statName;
    [SerializeField]
    private float value = 1;

    [Inject]
    private Player PlayerInstance { get; set; }
    public Float CacheStat { get; private set; }
    public TMP_Text StatValueText { get => statValueText; set => statValueText = value; }

    public override void Init()
    {
        Float stat = PlayerInstance.PlayerStats.GetStat(statName);
        CacheStat = stat;
        SetText(CacheStat.Value);
        StatNameText.SetText(statName);
        CacheStat.OnValueChanged += SetText;
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnButtonClick);
    }

    public override void DetachEvents()
    {
        CacheStat.OnValueChanged -= SetText;
        Button.onClick.RemoveAllListeners();
    }

    public override void SetText(float value)
    {
        StatValueText.SetText(value.ToString());
    }

    public override void OnButtonClick()
    {
        if (Cost.TryBuy())
            CacheStat.AddValue(value);
    }
}
