using System.Collections;
using UnityEngine;

[System.Serializable]
public class InfinityWave : WaveBase
{
    bool v = true;
    public override IEnumerator InitializeWave()
    {
            Debug.Log("start");
        yield return new WaitForSeconds(3);

            Debug.Log("spawning");
        while (v)
        {
            Vector3 randomPoint = Random.insideUnitCircle.normalized * Range;
            Vector3 spawnPoint = CachedPlayerTransform.position + randomPoint;
            int randomEnemyId = Random.Range(0, Enemies.Count);

            GameObject enemy = Enemies[randomEnemyId];
            GameObject.Instantiate(enemy, spawnPoint, Quaternion.identity);

            yield return WaitForSecond;
        }
        Debug.Log("end");
    }
}
