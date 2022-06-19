using System.Collections;
using UnityEngine;

[System.Serializable]
public class BasicWave : WaveBase
{
    [SerializeField]
    private int enemyCount;
    [SerializeField]
    private float enemyCountMultiplier;

    private int WaveNumber { get; set; }

    public override void AddEnemy()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator InitializeWave()
    {
        WaveNumber++;
        WaitForSecond = new WaitForSeconds(1 / enemyCountMultiplier);

        for (int i = 0; i < enemyCount * enemyCountMultiplier; i++)
        {
            yield return WaitForSecond;

            Vector3 randomPoint = Random.insideUnitCircle.normalized * Range;
            Vector3 spawnPoint = CachedPlayerTransform.position + randomPoint;
            int randomEnemyId = Random.Range(0, Enemies.Count);

            Enemy enemy = Enemies[randomEnemyId];
            Enemy createEnemy = GameObject.Instantiate(enemy, spawnPoint, Quaternion.identity);
            createEnemy.Init(WaveNumber);
        }

        GameManager.Instance.ChangeWaveState();
    }
}


[System.Serializable]
public class InfinityWave : WaveBase
{
    bool v = true;

    public override void AddEnemy()
    {
        Vector3 randomPoint = Random.insideUnitCircle.normalized * Range;
        Vector3 spawnPoint = CachedPlayerTransform.position + randomPoint;
        int randomEnemyId = Random.Range(0, Enemies.Count);

        Enemy enemy = Enemies[randomEnemyId];
        GameObject.Instantiate(enemy, spawnPoint, Quaternion.identity);
        EnemyCount.AddValue(1);
    }

    public override IEnumerator InitializeWave()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(3);

        Debug.Log("spawning");
        while (v)
        {
            AddEnemy();
            yield return WaitForSecond;
        }
        Debug.Log("end");
    }
}
