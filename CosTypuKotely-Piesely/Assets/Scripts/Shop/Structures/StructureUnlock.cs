using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureUnlock : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [SerializeField]
    private TMPro.TMP_Text costText;
    [SerializeField]
    private TMPro.TMP_Text typeText;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private InfoTemplate infoTemplate;
    [SerializeField]
    private Transform contentInfo;

    public void Init(StructureInfo info)
    {
        nameText.SetText(info.Name.ToString());
        costText.SetText(info.UnlockCost.ToString());
        typeText.SetText(info.Type.ToString());
        icon.sprite = info.Icon;
    }
}
