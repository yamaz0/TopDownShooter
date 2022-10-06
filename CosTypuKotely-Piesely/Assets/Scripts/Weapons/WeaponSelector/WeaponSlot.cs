
[System.Serializable]
public class WeaponSlot : Slot
{
    Weapon weapon;

    public Weapon Weapon { get => weapon; set => weapon = value; }

    public WeaponSlot(int number) : base(number)
    {

    }

    public void SetWeapon(Weapon w)
    {
        Weapon = w;
    }
}
