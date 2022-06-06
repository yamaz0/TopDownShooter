using System.Collections;
using UnityEngine;

[System.Serializable]
public class Magazine
{
    [SerializeField]
    private int magazineSize;

    public int MagazineMaxSize { get => magazineSize; set => magazineSize = value; }
    public int CurrentMagazineSize { get; private set; }

    public bool IsReloading;

    public event System.Action<int> OnMagazineSizeChanged = delegate { };
    public event System.Action<int> OnMagazineMaxSizeChanged = delegate { };

    public void Init()
    {
        SetAmmo(MagazineMaxSize);
    }

    public void SetAmmo(int value)
    {
        CurrentMagazineSize = value;
        OnMagazineSizeChanged(CurrentMagazineSize);
    }

    public void AddAmmo(int amount)
    {
        SetAmmo(CurrentMagazineSize + amount);
    }

    public bool CheckMagazine()
    {
        if (CurrentMagazineSize <= 0)
        {
            IsReloading = true;
        }

        return IsReloading;
    }

    public IEnumerator ReloadCorutine()
    {
        yield return new WaitForSeconds(2);
        SetAmmo(MagazineMaxSize);
        IsReloading = false;
    }
}
