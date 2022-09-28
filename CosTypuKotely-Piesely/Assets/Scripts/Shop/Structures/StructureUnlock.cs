using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
    private Button btn;
    [SerializeField]
    private InfoTemplate infoTemplate;
    [SerializeField]
    private Transform contentInfo;

    [SerializeField]
    private StructureInfo CacheInfo { get; set; }

    [Inject]
    private Player PlayerInstance { get; set; }

    public void Init(StructureInfo info)
    {
        CacheInfo = info;
        nameText.SetText(info.Name.ToString());
        costText.SetText(info.UnlockCost.Value.ToString());
        typeText.SetText(info.Type.ToString());
        icon.sprite = info.Icon;
    }

    public void SetUnlockVisibility(bool state)
    {
        btn.gameObject.SetActive(state);
        costText.gameObject.SetActive(state);
    }

    public void OnButtonClicked()
    {
        if (CacheInfo.UnlockCost.TryBuy())
        {
            Unlock();
        }
        else
        {
            Debug.Log("Nie stac cie na odblokowanie tej struktury!");
        }
    }

    private void Unlock()
    {
        PlayerInstance.PlayerBuild.UnlockStructure(CacheInfo.Id);
        SetUnlockVisibility(false);
    }
}
