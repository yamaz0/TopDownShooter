using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Singleton<BuildManager>
{
    [SerializeReference]
    private List<StructureBase> structures;

    public void Build(StructureTemplate template)
    {
        if (template == null) return;

        StructureBase searchStructure = null;

        for (int i = 0; i < structures.Count; i++)
        {
            if (structures[i].Type == template.Info.Type)
            {
                searchStructure = structures[i];
            }
        }

        if (searchStructure == null) return;

        StructureBase x = Instantiate(searchStructure, template.transform.position, Quaternion.identity);
        x.Build(template.Info);
    }
}