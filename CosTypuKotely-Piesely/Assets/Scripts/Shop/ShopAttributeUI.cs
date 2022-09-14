using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class ShopAttributeUI : MonoBehaviour
{

    [SerializeField]
    private TMPro.TMP_Text statNameText;
    [SerializeField]
    private TMPro.TMP_Text costValueText;
    [SerializeField]
    private Button button;
    [SerializeField]
    private Cost cost;
    public TMP_Text StatNameText { get => statNameText; set => statNameText = value; }
    public Cost Cost { get => cost; set => cost = value; }
    public Button Button { get => button; set => button = value; }
    public TMP_Text CostValueText { get => costValueText; set => costValueText = value; }

    public abstract void Init();
    public abstract void DetachEvents();
    public abstract void SetText(float value);
    public abstract void OnButtonClick();

}
