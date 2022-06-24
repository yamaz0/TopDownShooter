using System.Collections;
using UnityEngine;


[System.Serializable]
public class InfinityWave : WaveBase
{
    bool isWaveEnable = true;
    int waveNumber = 0;
    int enemiesToSpawn = 10;

    public override void AddEnemy()
    {
        Vector3 randomPoint = Random.insideUnitCircle.normalized * Range;
        Vector3 spawnPoint = CachedPlayerTransform.position + randomPoint;
        int randomEnemyId = Random.Range(0, Enemies.Count);

        Enemy enemy = Enemies[randomEnemyId];
        Enemy newEnemy = GameObject.Instantiate(enemy, spawnPoint, Quaternion.identity);
        newEnemy.Init(waveNumber);
        WaveManager.Instance.EnemiesCounter.AddValue(1);
        EnemyCount++;
    }

    public override IEnumerator InitializeWave()
    {
        WaveManager.Instance.EnemiesCounter.AddValue(1);//Cheat zeby faza fali nigdy sie nie skonczyla
        while (isWaveEnable)
        {
            yield return new WaitForSeconds(5);

            for (int i = 0; i < enemiesToSpawn && isWaveEnable; i++)
            {
                AddEnemy();
                yield return WaitForSecond;
            }

            waveNumber++;
            enemiesToSpawn += 5;
        }

    }
}
