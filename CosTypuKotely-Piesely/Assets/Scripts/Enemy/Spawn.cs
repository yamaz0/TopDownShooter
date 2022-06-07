using UnityEngine;

public partial class Spawn : MonoBehaviour
{
    [SerializeReference]
    private WaveBase wave = new InfinityWave();//do przerobienia na bardziej zlozone

    public WaveBase Wave { get => wave; set => wave = value; }

    void Start()
    {
        Wave.CachedPlayerTransform = Player.Instance.gameObject.transform;
        StartCoroutine(Wave.InitializeWave());
    }
}
