using UnityEngine;

public class SingletonPersistence<T> : MonoBehaviour where T : SingletonPersistence<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError(typeof(T) + " is NULL.");
            }

            return instance;
        }
    }

    protected virtual void Initialize()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else if (instance != this)
        {
            Destroy(gameObject.GetComponent(Instance.GetType()));
        }
        Initialize();
        DontDestroyOnLoad(gameObject);
    }
}