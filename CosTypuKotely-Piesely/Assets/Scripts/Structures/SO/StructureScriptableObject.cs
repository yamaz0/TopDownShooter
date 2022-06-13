using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureScriptableObject", menuName = "SO/StructureScriptableObject")]
public partial class StructureScriptableObject : SingletonScriptableObject<StructureScriptableObject>
{
    public StructureInfo GetStructureInfoById(int id)
    {
        return (StructureInfo)Objects.GetElementById(id);
    }

    public StructureInfo GetStructureInfoByName(string name)
    {
        return (StructureInfo)Objects.GetElementByName(name);
    }

    public List<StructureInfo> GetStructuresList()
    {
        List<StructureInfo> Structures = new List<StructureInfo>(Objects.Count);

        foreach (StructureInfo Structure in Objects)
        {
            Structures.Add(Structure);
        }

        return Structures;
    }

    // private void OnValidate()
    // {
    //     foreach (StructureInfo Structure in Objects)
    //     {
    //         if (Structure.DamagedIcon == null)
    //             Structure.DamagedIcon = Resources.LoadAll<Sprite>("")[0];
    //     }
    // }
}
