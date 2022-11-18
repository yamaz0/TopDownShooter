using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text currentWaveText;
    [SerializeField]
    private TMPro.TMP_Text waveCountText;
    [SerializeField]
    private TMPro.TMP_Text enemiesLeftText;

    private void Start()
    {
        SetCurrentWaveNumber();
        SetEnemiesLeftCount();
        waveCountText.SetText(WaveManager.Instance.WavesCount.ToString());
    }

    private void OnEnable()
    {
        WaveManager.Instance.OnWaveStart += SetCurrentWaveNumber;
        WaveManager.Instance.OnEnemyCountChanged += SetEnemiesLeftCount;
    }

    private void OnDisable()
    {
        WaveManager.Instance.OnWaveStart -= SetCurrentWaveNumber;
        WaveManager.Instance.OnEnemyCountChanged -= SetEnemiesLeftCount;
    }

    public void SetCurrentWaveNumber()
    {
        currentWaveText.SetText(WaveManager.Instance.CurrentWaveNumber.ToString());
    }

    public void SetEnemiesLeftCount()
    {
        enemiesLeftText.SetText(WaveManager.Instance.SpawnedEnemies.Count.ToString());
    }
}
