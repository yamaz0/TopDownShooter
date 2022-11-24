using UnityEngine;

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
