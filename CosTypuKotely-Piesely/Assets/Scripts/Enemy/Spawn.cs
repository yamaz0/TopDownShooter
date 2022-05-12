using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private Enemy template;
    [SerializeField]
    private float range = 12f;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 1);
    }

    public void SpawnEnemy()
    {
        Vector3 randomPoint = Random.insideUnitCircle.normalized * range;
        Vector3 spawnPoint = Player.Instance.gameObject.transform.position + randomPoint;
        Instantiate(template, spawnPoint, Quaternion.identity);
    }

}
