using UnityEngine;

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
