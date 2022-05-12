using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private float range = 17f;

    private WaitForSeconds WaitForSecond { get; set; } = new WaitForSeconds(1);
    private Transform CachedPlayerTransform { get; set; }

    void Start()
    {
        CachedPlayerTransform = Player.Instance.gameObject.transform;
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        Debug.Log("start");
        Vector3 randomPoint = Random.insideUnitCircle.normalized * range;
        Vector3 spawnPoint = CachedPlayerTransform.position + randomPoint;
        int randomEnemyId = Random.Range(0, enemies.Count);

        GameObject enemy = enemies[randomEnemyId];
        Instantiate(enemy, spawnPoint, Quaternion.identity, transform);

        yield return WaitForSecond;
        StartCoroutine(SpawnEnemy());
        Debug.Log("end");
    }
}
