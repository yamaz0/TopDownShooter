using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildingUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text costText;
    [SerializeField]
    private Image icon;

    public StructureInfo CacheStructureInfo { get; private set; }

    [Inject]
    private Player PlayerInstance { get; set; }

    public void SetStructure(StructureInfo info)
    {
        CacheStructureInfo = info;
        costText.SetText(info.BuildCost.Value.ToString());
        icon.sprite = info.Icon;
    }

    private void OnEnable()
    {
        PlayerInstance.PlayerBuild.OnStructureChanged += SetStructure;
    }

    private void OnDisable()
    {
        PlayerInstance.PlayerBuild.OnStructureChanged -= SetStructure;
    }
}
