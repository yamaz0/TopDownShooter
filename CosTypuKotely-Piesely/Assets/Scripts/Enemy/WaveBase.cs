using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class WaveBase
{
    public WaitForSeconds WaitForSecond { get; set; } = new WaitForSeconds(1);
    public Transform CachedPlayerTransform { get; set; }
    public float Range { get => range; set => range = value; }
    public List<GameObject> Enemies { get => enemies; set => enemies = value; }

    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private float range = 17f;
    public abstract IEnumerator InitializeWave();
}
