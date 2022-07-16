using UnityEngine;


public abstract class WaveEndConditionBase
{
    public abstract bool CheckEndWave();
    public abstract void Attach();
    public abstract void Detach();
    protected void EndWave()
    {
        if (CheckEndWave() == true)
            WaveManager.Instance.EndWave();
    }
}

public class WaveEndEnemyCountCondition : WaveEndConditionBase
{
    public override bool CheckEndWave()
    {
        if (WaveManager.Instance.EnemiesCounter.Value >= WaveManager.Instance.EnemiesOnWave)
            return true;
        return false;
    }

    public void EndWaveCheckConditionCheat(float a)
    {
        EndWave();
    }

    public override void Attach()
    {
        WaveManager.Instance.EnemiesCounter.OnValueChanged += EndWaveCheckConditionCheat;
    }

    public override void Detach()
    {
        WaveManager.Instance.EnemiesCounter.OnValueChanged -= EndWaveCheckConditionCheat;
    }
}

// Specify what you want to happen when the Elapsed event is raised.
public class WaveEndTimeCondition : WaveEndConditionBase
{
    [SerializeField]
    private float waveDuration;
    float endWaveTime;//moze nie potrzebne ale do testu na razie
    System.Timers.Timer timer;

    private void OnElapsed(object source, System.Timers.ElapsedEventArgs e)
    {
        EndWave();
    }

    public override bool CheckEndWave()
    {
        if (Time.unscaledTime >= endWaveTime)
            return true;
        return false;
    }

    public override void Attach()
    {
        endWaveTime = Time.unscaledTime + waveDuration;

        timer = new System.Timers.Timer();
        timer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsed);
        timer.Interval = waveDuration;
        timer.Start();
    }

    public override void Detach()
    {
       timer.Close();
    }
}

public class WaveManager : Singleton<WaveManager>
{
    [SerializeField]
    private bool isWave = false;
    [SerializeField]
    private Spawn spawner;
    public bool IsWave { get => isWave; set => isWave = value; }
    [SerializeField]
    private StatementTextUI statementTextUI;

    public Float EnemiesCounter { get; set; }
    public Spawn Spawner { get => spawner; set => spawner = value; }
    public int EnemiesOnWave { get; set; }

    public event System.Action OnWaveStart = delegate { };
    public event System.Action OnWaveEnd = delegate { };

    private void Start()
    {
        EnemiesCounter = new Float(0);
        // EnemiesCounter.OnValueChanged += CheckWaveEnd;
    }

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

    public void AddEnemyCount(int val)
    {
        EnemiesOnWave += val;
    }

    public void ChangeWaveState(bool state)
    {
        isWave = state;
        InputManager.Instance.ActionMapSetActiv("States", !state);
    }

    public void StartWave()
    {
        Spawner.StartWave();
        ChangeWaveState(true);
        InputManager.Instance.ActionMapSetActiv("Building", false);
        InputManager.Instance.ActionMapSetActiv("Shooting", true);
        statementTextUI.ShowText("Wave Start");
        Player.Instance.PlayerBuild.ShowTemplate(false);
        ResetWave();
        OnWaveStart();
    }

    private void ResetWave()
    {
        EnemiesOnWave = 0;
        EnemiesCounter.SetValue(0);
    }

    public void EndWave()
    {
        ChangeWaveState(false);
        statementTextUI.ShowText("Wave End");
        OnWaveEnd();
    }
}
