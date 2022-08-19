using UnityEngine;
using Zenject;

[System.Serializable]
public class StatUI: MonoBehaviour
{
    [SerializeField]
    private string statName;
    [SerializeField]
    private TMPro.TMP_Text statValueText;
    [SerializeField]
    private TMPro.TMP_Text statNameText;

    [Inject]
    private Player PlayerInstance { get; set; }
    public Float CacheStat { get; private set; }

    public void Init()
    {
        Float stat = PlayerInstance.PlayerStats.GetStat(statName);
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
