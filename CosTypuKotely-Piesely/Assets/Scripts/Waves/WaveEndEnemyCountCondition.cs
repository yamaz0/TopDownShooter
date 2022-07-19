[System.Serializable]
public class WaveEndEnemyCountCondition : WaveEndConditionBase
{
    public override bool CheckEndWave()
    {
        if (WaveManager.Instance.EnemiesCounter.Value <= 0)
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
