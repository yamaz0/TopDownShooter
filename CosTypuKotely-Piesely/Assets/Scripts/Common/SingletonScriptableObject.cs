using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
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
}
