using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureShop : MonoBehaviour
{
    [SerializeField]
    private StructureUnlock template;
    [SerializeField]
    private Transform content;

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
        List<StructureInfo> structuresInfo = StructureScriptableObject.Instance.GetStructuresList();

        Structures.ClearAndDestroy();

        foreach (var info in structuresInfo)
        {
            StructureUnlock newStructureUnlock = Instantiate(template, content);
            bool isUnlocked = Player.Instance.PlayerBuild.UnlockStructureIds.Contains(info.Id);

            newStructureUnlock.gameObject.SetActive(true);
            newStructureUnlock.Init(info);
            newStructureUnlock.SetUnlockVisibility(!isUnlocked);

            Structures.Add(newStructureUnlock);
        }
    }
}
