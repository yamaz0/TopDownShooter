using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField]
    private int currentWaveNumber;
    [SerializeField]
    private int wavesCount;
    [SerializeField]
    private bool isWave = false;


    [SerializeField]
    private StatementTextUI startWaveText;
    [SerializeField]
    private StatementTextUI endWaveText;
    [SerializeReference]
    private WaveEndConditionBase x = new WaveEndEnemyCountCondition();

    public List<Enemy> SpawnedEnemies { get; private set; } = new List<Enemy>();
    public bool IsAllSpawn = false;
    public bool IsWave { get => isWave; set => isWave = value; }

    public Float EnemiesCounter { get; set; } = new Float(0);

    public event System.Action OnWaveStart = delegate { };
    public event System.Action OnEnemyCountChanged = delegate { };
    // public event System.Action OnWaveEnd = delegate { };


    [Inject]
    private Player PlayerInstance { get; set; }
    public int CurrentWaveNumber { get => currentWaveNumber; set => currentWaveNumber = value; }
    public int WavesCount { get => wavesCount; set => wavesCount = value; }

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
    public void Init()
    {
        //tutaj wszystkie poczatkowe wartosci przypisac
        WavesCount = MapManager.Instance.SelectedMap.Waves.Count;
        StartWave();
    }

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
        CurrentWaveNumber++;
        OnWaveStart();
        StartCoroutine(MapManager.Instance.SelectedMap.Waves[CurrentWaveNumber - 1].InitializeWave());//todo przechowac referencje w wavemanagerze
        x.Attach();
    }

    private void ResetWave()
    {
        EnemiesCounter.SetValue(0);
    }

    public void EndWave()
    {
        if (CheckWavesEmpty())
        {
            //todo wygrana mapy i wyjscie do menu po kliknieciu
            WindowManager.Instance.ShowWinCanvas();
            // Debug.Log("wygranko");
            // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {

            IsAllSpawn = false;
            x.Detach();
            ChangeWaveState(false);
            endWaveText.ShowText();
            // OnWaveEnd();
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        SpawnedEnemies.Remove(enemy);
        NotifyEnemyCountChanged();
    }

    public void NotifyEnemyCountChanged()
    {
        OnEnemyCountChanged();
    }

    private bool CheckWavesEmpty() => CurrentWaveNumber >= WavesCount;
}
