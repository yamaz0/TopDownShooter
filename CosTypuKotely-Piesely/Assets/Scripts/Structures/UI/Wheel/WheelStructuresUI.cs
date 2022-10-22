using System.Collections.Generic;
using Zenject;

public class WheelStructuresUI : SelectElementsUI
{
    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        Dictionary<int, StructureSlot> structuresSlots = PlayerInstance.PlayerBuild.Selector.Slots;
        int index = 0;

        foreach (WheelStructureElementUI element in Elements)
        {
            structuresSlots.TryGetValue(index, out StructureSlot slot);
            index++;
            if (slot == null) continue;
            element.Init(slot);
        }
    }
}
