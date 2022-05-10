using UnityEngine;

[System.Serializable]
public class BaseInfo
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string name;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
}
