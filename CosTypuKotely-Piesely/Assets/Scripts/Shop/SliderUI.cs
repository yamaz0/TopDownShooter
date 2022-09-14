using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SliderUI : ShopAttributeUI
{
    private const int MAX_LVL = 4;
    [SerializeField]
    private string lightAtributeName;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private List<float> values;

    public override void DetachEvents()
    {
        Button.onClick.RemoveAllListeners();
    }

    public override void Init()
    {
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnButtonClick);
        Cost.SetLevel((int)slider.value);
        SetText(Cost.GetCostAtLevel((int)slider.value));
    }

    public override void OnButtonClick()
    {
        if (Cost.TryBuy())
        {
            Float stat = Player.Instance.PlayerLight.GetStat(lightAtributeName);
            float value = GetValue();
            stat.SetValue(value);

            slider.value++;
            Cost.SetLevel((int)slider.value);

            if (slider.value >= MAX_LVL)
            {
                Button.enabled = false;
            }
        }
    }

    private float GetValue()
    {
        return values[(int)slider.value];
    }

    public override void SetText(float value)
    {
        CostValueText.SetText(value.ToString());
    }
}
