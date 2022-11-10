using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class WaveBase
{
    [SerializeField]
    private List<GroupEnemies> enemiesGroups;
    [SerializeField]
    private float range = 17f;

    public Transform CachedPlayerTransform { get; set; }
    public float Range { get => range; set => range = value; }
    public List<GroupEnemies> EnemiesGroups { get => enemiesGroups; set => enemiesGroups = value; }
    public abstract IEnumerator InitializeWave();
    public int EnemyCount { get; set; }
    public event System.Action<float> OnEnemyCountChanged = delegate { };
}

[System.Serializable]
public class GroupEnemies
{
    [SerializeField]
    private List<int> enemiesID;//tu chyba najlepiej idki
    [SerializeField]
    private float timeToSpawn;

    public List<int> EnemiesID { get => enemiesID; set => enemiesID = value; }
    public float TimeToSpawn { get => timeToSpawn; set => timeToSpawn = value; }
}
