using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField]
    private bool isWave = false;
    [SerializeField]
    private int enemiesCounter;
    [SerializeField]
    private Spawn spanwer;
    public bool IsWave { get => isWave; set => isWave = value; }
    public int EnemiesCounter { get => enemiesCounter; set => enemiesCounter = value; }

    public event System.Action OnWaveStartChanged = delegate { };
    public event System.Action OnWaveEndChanged = delegate { };
    public event System.Action<int> OnEnemyCountChanged = delegate { };


    private void Start()
    {
        OnEnemyCountChanged += CheckWaveEnd;
    }

    private void OnDisable()
    {
        OnEnemyCountChanged -= CheckWaveEnd;
    }

    public void AddEnemyCounter(int amount)
    {
        EnemiesCounter += amount;
        OnEnemyCountChanged(EnemiesCounter);
    }

    public void CheckWaveEnd(int amount)
    {
        if (amount <= 0)
        {
            EndWave();
        }
    }

    public void ChangeWaveState(bool state)
    {
        isWave = state;
        InputManager.Instance.ActionMapSetActiv("States", !state);
    }

    public void InitWave(WaveBase wave)
    {
        EnemiesCounter = wave.EnemyCount;
    }

    public void StartWave()
    {
        spanwer.StartWave();
        ChangeWaveState(true);
        OnWaveStartChanged();
    }

    public void EndWave()
    {
        ChangeWaveState(false);
        OnWaveEndChanged();
    }
}
