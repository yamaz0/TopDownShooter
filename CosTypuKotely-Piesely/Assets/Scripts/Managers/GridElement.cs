using UnityEngine;

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
