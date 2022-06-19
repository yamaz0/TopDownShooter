using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class WaveBase
{
    [SerializeField]
    private List<Enemy> enemies;
    [SerializeField]
    private float range = 17f;

    public WaitForSeconds WaitForSecond { get; set; } = new WaitForSeconds(1);
    public Transform CachedPlayerTransform { get; set; }
    public float Range { get => range; set => range = value; }
    public List<Enemy> Enemies { get => enemies; set => enemies = value; }
    public abstract IEnumerator InitializeWave();
    public Float EnemyCount { get; private set; }
    public abstract void AddEnemy();
    public event System.Action<float> OnEnemyCountChanged = delegate { };
}
