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

[System.Serializable]
public class Grid
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    private int cellSize;
    [SerializeField]
    private bool debug;
    private GridObject[,] gridArray;

    public void Build(int x, int y, StructureBase structure)
    {
        bool canBuild = CanBuild(x, y, structure.Info.Height, structure.Info.Width);

        if (canBuild == true)
        {
            gridArray[x, y].Init(x, y, structure, gridArray);
        }

    }

    public void DrawDebug()
    {
        if (debug)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Debug.DrawLine(new Vector3(i * cellSize, j * cellSize, 0), new Vector3(i * cellSize, (j + 1) * cellSize, 0), Color.red);
                    Debug.DrawLine(new Vector3(i * cellSize, j * cellSize, 0), new Vector3((i + 1) * cellSize, j * cellSize, 0), Color.red);
                }
            }
            Debug.DrawLine(new Vector3(width * cellSize, height * cellSize, 0), new Vector3(width * cellSize, 0, 0), Color.red);
            Debug.DrawLine(new Vector3(width * cellSize, height * cellSize, 0), new Vector3(0, height * cellSize, 0), Color.red);
        }
    }

    public Grid(int width, int height, int size)
    {
        this.width = width;
        this.height = height;
        this.cellSize = size;
        gridArray = new GridObject[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                gridArray[i, j] = new GridObject();
            }
        }
    }

    public bool CanBuild(int x, int y, int height, int width)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (gridArray[x + i, y + j].CanBuild == false)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public Vector2Int GetGridXYByPosition(Vector3 position)
    {
        int x = (int)(position.x / cellSize);
        int y = (int)(position.y / cellSize);
        return new Vector2Int(x, y);
    }

    public Vector3 GetGlobalPosition(int x, int y)
    {
        return new Vector3(x * cellSize, y * cellSize, 0);
    }
}

[System.Serializable]
public class GridObject : GridElement
{
    [SerializeField]
    private int x;
    [SerializeField]
    private int y;

    public StructureBase CacheStructure { get; private set; }
    public GridElement[,] CacheGridArray { get; private set; }

    public void Init(int x, int y, StructureBase structure, GridElement[,] grid)
    {
        this.x = x;
        this.y = y;
        CacheGridArray = grid;
        CacheStructure = structure;
        CacheStructure.OnDestroyed += Demolish;

        WithinGridObjectAction(Build);
    }

    public void Demolish()
    {
        WithinGridObjectAction(Unbuild);
        CacheStructure.OnDestroyed -= Demolish;
    }

    private void WithinGridObjectAction(System.Action<GridElement> action)
    {
        StructureInfo info = CacheStructure.Info;
        for (int i = 0; i < info.Width; i++)
        {
            for (int j = 0; j < info.Height; j++)
            {
                action(CacheGridArray[x + i, y + j]);
            }
        }
    }
}

[System.Serializable]
public class GridElement
{
    [SerializeField]
    bool canBuild = true;

    public bool CanBuild { get => canBuild; private set => canBuild = value; }

    public void Build(GridElement element)
    {
        element.CanBuild = false;
    }

    public void Unbuild(GridElement element)
    {
        element.CanBuild = true;
    }
}
