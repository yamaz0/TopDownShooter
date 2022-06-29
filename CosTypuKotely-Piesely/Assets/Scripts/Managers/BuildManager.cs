using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Singleton<BuildManager>
{
    [SerializeReference]
    private List<StructureBase> structures;
    [SerializeField]
    private float buildCooldownTime;
    [SerializeField]
    private bool CanBuild = true;

    public void Build(StructureTemplate template)
    {
        if (CanBuild == false) return;
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

        CanBuild = false;
        StartCoroutine(BuildCooldown());
    }

    private IEnumerator BuildCooldown()
    {
        yield return new WaitForSeconds(buildCooldownTime);
        CanBuild = true;
    }
}