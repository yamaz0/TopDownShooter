using System.Collections.Generic;
using Zenject;

public class WheelWeaponsUI : SelectElementsUI
{
    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        List<WeaponSlot> weaponsSlots = PlayerInstance.PlayerWeapons.WeaponsSelector.WeaponsSlots;
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
