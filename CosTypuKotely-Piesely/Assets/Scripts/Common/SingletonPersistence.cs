using UnityEngine;

public abstract class SingletonPersistence<T> : Singleton<T> where T : SingletonPersistence<T>
{
    protected override void Initialize()
    {
        DontDestroyOnLoad(gameObject);
    }
}