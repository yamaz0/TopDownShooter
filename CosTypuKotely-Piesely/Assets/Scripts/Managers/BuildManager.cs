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

    [SerializeField]
    private Grid grid = new Grid(100, 50, 1);

    public Grid Grid { get => grid; private set => grid = value; }

    private void OnDrawGizmos()
    {
        Grid.DrawDebug();
    }
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
        Vector2Int vector2Int = Grid.GetGridXYByPosition(template.PlaceTransform.position);
        bool checkGrid = Grid.CanBuild(vector2Int.x, vector2Int.y, template.Info.Height, template.Info.Width);

        if (checkGrid == false) return;
        Vector3 pos = Grid.GetGlobalPosition(vector2Int.x, vector2Int.y);
        StructureBase x = Instantiate(searchStructure, pos, Quaternion.identity);
        x.Build(template.Info);
        Grid.Build(vector2Int.x, vector2Int.y, x);

        CanBuild = false;
        StartCoroutine(BuildCooldown());
    }

    private IEnumerator BuildCooldown()
    {
        yield return new WaitForSeconds(buildCooldownTime);
        CanBuild = true;
    }
}
