using UnityEngine;

public class InfoTemplate : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [SerializeField]
    private TMPro.TMP_Text valueText;

    public void Init(string name, string value)
    {
        nameText.SetText(name);
        valueText.SetText(value);
    }
}
