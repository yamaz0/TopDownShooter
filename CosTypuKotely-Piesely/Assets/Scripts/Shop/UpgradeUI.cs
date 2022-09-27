[System.Serializable]
public class UpgradeUI : ShopAttributeUI
{
    public override void DetachEvents()
    {
        Button.onClick.RemoveAllListeners();
    }

    public override void Init()
    {
        CostValueText.SetText(Cost.Value.ToString());
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnButtonClick);
    }

    public override void OnButtonClick()
    {
        if (Cost.TryBuy())
        {
            Player.Instance.PlayerStats.DualShoot = true;
            Button.enabled = false;
            StatNameText.SetText("Double shoot - BOUGHT");
            CostValueText.SetText("---");
        }
    }

    public override void SetText(float value)
    {
        StatNameText.SetText("Double shoot");
    }
}
