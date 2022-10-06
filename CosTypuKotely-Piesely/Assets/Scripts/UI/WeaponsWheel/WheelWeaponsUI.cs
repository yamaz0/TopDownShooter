using System.Collections.Generic;
using Zenject;

public class WheelWeaponsUI : SelectElementsUI
{
    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        Dictionary<int, WeaponSlot> weaponsSlots = PlayerInstance.PlayerWeapons.WeaponsSelector.Slots;
        int index = 0;
        //TODO wybrana bron jest jako wybrana - napis na srodku sie zmienia na start
        foreach (WheelWeaponsElementUI element in Elements)
        {
            weaponsSlots.TryGetValue(index, out WeaponSlot slot);
            index++;
            if (slot == null) continue;
            element.Init(slot);
        }
    }
}
