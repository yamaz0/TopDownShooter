using System;
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

    public BaseInfo(BaseInfo info)
    {
        Id = info.Id;
        Name = info.Name;
    }

#if UNITY_EDITOR
    public virtual void ShowFields()
    {
        GUILayout.Label("Id: " + Id.ToString());
        Name = UnityEditor.EditorGUILayout.TextField("Name: ", Name);
    }

    public void ShowBaseBaseInfo()
    {
        // GUILayout.Box(GenerateTextureFromSprite(Icon), GUILayout.Width(100), GUILayout.Height(50));
        GUILayout.Label("Id: " + Id.ToString());
        GUILayout.Label(Name);
    }

    public virtual void ShowAllBaseInfo()
    {
        ShowBaseBaseInfo();
    }
#endif
}
