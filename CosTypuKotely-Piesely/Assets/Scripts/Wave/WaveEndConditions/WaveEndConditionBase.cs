[System.Serializable]
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
