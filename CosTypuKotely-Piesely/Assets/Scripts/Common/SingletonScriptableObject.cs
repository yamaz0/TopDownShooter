using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class SingletonScriptableObject<T> : ScriptableObject, IEditorWindowData where T : SingletonScriptableObject<T>
{
    private static T instance;

    [SerializeReference]
    private List<BaseInfo> objects = new List<BaseInfo>();

    public static T Instance { get => instance; set => instance = value; }
    public List<BaseInfo> Objects { get => objects; set => objects = value; }

    [RuntimeInitializeOnLoadMethod]
    public void Init()
    {
        instance = Resources.LoadAll<T>("")[0];
    }
    private void OnEnable()
    {
        Init();
    }
#if UNITY_EDITOR
    public void AddBaseInstance(BaseInfo info)
    {
        bool notExists = Objects.ContainsId(info) == false;

        if (info != null && notExists)
        {
            Objects.Add(info);
            EditorUtility.SetDirty(this);
        }
    }

    public void UpdateBaseInstance(BaseInfo info)
    {
        if (info != null)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Id == info.Id)
                {
                    Objects[i] = info;
                    EditorUtility.SetDirty(this);
                    return;
                }
            }
        }
    }

    public void RemoveBaseInstance(BaseInfo info)
    {
        if (info != null)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Id == info.Id)
                {
                    Objects.RemoveAt(i);
                    EditorUtility.SetDirty(this);
                    return;
                }
            }
        }
    }
#endif
}
