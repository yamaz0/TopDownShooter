using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField]
    private bool isWave = false;
    [SerializeField]
    private Spawn spawner;
    public bool IsWave { get => isWave; set => isWave = value; }
    [SerializeField]
    private StatementTextUI startWaveText;
    [SerializeField]
    private StatementTextUI endWaveText;
    [SerializeReference]
    private WaveEndConditionBase x = new WaveEndEnemyCountCondition();

    public List<Enemy> SpawnedEnemies { get; private set; }
    public bool IsAllSpawn = false;

    public Float EnemiesCounter { get; set; } = new Float(0);
    public Spawn Spawner { get => spawner; set => spawner = value; }

    public event System.Action OnWaveStart = delegate { };
    public event System.Action OnWaveEnd = delegate { };


    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnDisable()
    {
        // EnemiesCounter.OnValueChanged -= CheckWaveEnd;
    }

    // public void CheckWaveEnd(float amount)
    // {
    //     if (amount <= 0)
    //     {
    //         EndWave();
    //     }
    // }

    public void ChangeWaveState(bool state)
    {
        isWave = state;
        InputManager.Instance.ActionMapSetActiv("States", !state);
    }

    public void StartWave()
    {
        ChangeWaveState(true);
        InputManager.Instance.ActionMapSetActiv("Building", false);
        InputManager.Instance.ActionMapSetActiv("Shooting", true);
        startWaveText.ShowText();
        PlayerInstance.PlayerBuild.ShowTemplate(false);
        ResetWave();
        OnWaveStart();
        Spawner.StartWave();
        x.Attach();
    }

    private void ResetWave()
    {
        EnemiesCounter.SetValue(0);
    }

    public void EndWave()
    {
        IsAllSpawn = false;
        x.Detach();
        ChangeWaveState(false);
        endWaveText.ShowText();
        OnWaveEnd();
    }
}
