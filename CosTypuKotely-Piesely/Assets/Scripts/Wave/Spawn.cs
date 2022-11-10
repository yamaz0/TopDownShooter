using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeReference]
    private WaveBase wave = new BasicWave();//do przerobienia na bardziej zlozone

    public WaveBase Wave { get => wave; set => wave = value; }

    void Start()
    {
        Wave.CachedPlayerTransform = Player.Instance.gameObject.transform;
    }

    public void StartWave()
    {
        StartCoroutine(Wave.InitializeWave());
    }
}
