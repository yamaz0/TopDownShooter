using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicWave : WaveBase
{

    public void AddEnemy(List<int> enemiesID)
    {
        for (int i = 0; i < enemiesID.Count; i++)
        {
            EnemyInfo info = EnemiesScriptableObject.Instance.GetEnemyInfoById(enemiesID[i]);
            Vector3 randomPoint = Random.insideUnitCircle.normalized * Range;
            Vector3 spawnPoint = CachedPlayerTransform.position + randomPoint;
            Enemy createdEnemy = GameObject.Instantiate(EnemiesScriptableObject.Instance.EnemyTemplate, spawnPoint, Quaternion.identity);
            createdEnemy.Init(info);
            // WaveManager.Instance.SpawnedEnemies.Add(createdEnemy);
        }
    }

    public override IEnumerator InitializeWave()
    {
        for (int i = 0; i < EnemiesGroups.Count; i++)
        {
            GroupEnemies e = EnemiesGroups[i];
            yield return new WaitForSeconds(e.TimeToSpawn);
            AddEnemy(e.EnemiesID);
            WaveManager.Instance.EnemiesCounter.AddValue(e.EnemiesID.Count);
        }
        WaveManager.Instance.IsAllSpawn = true;
    }

}
