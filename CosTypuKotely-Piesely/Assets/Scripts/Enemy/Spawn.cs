using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private Enemy template;
    [SerializeField]
    private Renderer spriteRenderer;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 1);
    }
    public void SpawnEnemy()
    {
        float distance = Vector3.Distance(Player.Instance.gameObject.transform.position, transform.position);
        // Debug.Log(distance);
        if (spriteRenderer.isVisible == false && distance < 25)
            Instantiate(template, transform);
    }

}
