using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SliderUI : ShopAttributeUI
{
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
    }

    public override void OnButtonClick()
    {
        if (Cost.TryBuy())
        {
            Player.Instance.PlayerLight.GetStat(lightAtributeName).SetValue(values[Cost.Level - 1]);
            slider.value++;
            if (Cost.Level == 4)
            {
                Button.enabled = false;
            }
        }
    }

    public override void SetText(float value)
    {
        throw new System.NotImplementedException();
    }
}
