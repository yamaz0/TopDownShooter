using System.Collections;
using UnityEngine;

[System.Serializable]
public class BasicWave : WaveBase
{
    [SerializeField]
    private int enemyCount;
    [SerializeField]
    private float time;

    private int WaveNumber { get; set; }

    public override void AddEnemy()
    {
        Vector3 randomPoint = Random.insideUnitCircle.normalized * Range;
        Vector3 spawnPoint = CachedPlayerTransform.position + randomPoint;
        int randomEnemyId = Random.Range(0, Enemies.Count);

        Enemy enemy = Enemies[randomEnemyId];
        Enemy createEnemy = GameObject.Instantiate(enemy, spawnPoint, Quaternion.identity);
        createEnemy.Init(WaveNumber);
    }

    public override IEnumerator InitializeWave()
    {
        WaveNumber++;
        WaveManager.Instance.AddEnemyCount(enemyCount);
        WaitForSecond = new WaitForSeconds(time);

        for (int i = 0; i < enemyCount; i++)
        {
            yield return WaitForSecond;
            AddEnemy();
        }
    }
}
