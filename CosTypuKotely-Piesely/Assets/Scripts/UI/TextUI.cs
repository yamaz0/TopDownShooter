using UnityEngine;

public class TextUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text nameText;

    public void SetName(string text)
    {
        nameText.SetText(text);
    }
}
