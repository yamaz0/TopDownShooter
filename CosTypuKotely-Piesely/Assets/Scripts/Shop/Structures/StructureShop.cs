using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StructureShop : MonoBehaviour
{
    [SerializeField]
    private StructureUnlock template;
    [SerializeField]
    private Transform content;

    [Inject]
    private Player PlayerInstance { get; set; }
    public List<StructureUnlock> Structures { get; private set; }

    private void OnEnable()
    {
        if (Structures == null)
        {
            Structures = new List<StructureUnlock>();
        }
        Refresh();
    }

    public void Refresh()
    {
        List<int> structuresId = MapManager.Instance.Options.ShopStructuresID;
        List<StructureInfo> unlockedStructuresInfo = Player.Instance.PlayerBuild.GetStructures();

        Structures.ClearAndDestroy();

        foreach (var id in structuresId)
        {
            StructureInfo info = StructureScriptableObject.Instance.GetStructureInfoById(id);
            StructureUnlock newStructureUnlock = Instantiate(template, content);
            bool isUnlocked = unlockedStructuresInfo.ContainsId(info.Id);

            newStructureUnlock.gameObject.SetActive(true);
            newStructureUnlock.Init(info);
            newStructureUnlock.SetUnlockVisibility(!isUnlocked);

            Structures.Add(newStructureUnlock);
        }
    }
}
