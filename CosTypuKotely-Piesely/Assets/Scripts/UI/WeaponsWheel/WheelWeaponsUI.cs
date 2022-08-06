using System.Collections.Generic;

public class WheelWeaponsUI : WheelUI
{
    private void OnEnable()
    {
        List<WeaponSlot> weaponsSlots = Player.Instance.PlayerWeapons.WeaponsSelector.WeaponsSlots;
        int index = 0;
        //TODO wybrana bron jest jako wybrana - napis na srodku sie zmienia na start
        foreach (WheelWeaponsElementUI element in Elements)
        {
            WeaponSlot weaponSlot = weaponsSlots[index];
            element.Init(weaponSlot);
            index++;
        }
    }
}
