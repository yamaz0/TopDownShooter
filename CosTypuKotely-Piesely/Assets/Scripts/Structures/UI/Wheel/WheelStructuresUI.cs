using System.Collections.Generic;
using Zenject;

public class WheelStructuresUI : SelectElementsUI
{
    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        // List<StructureSlot> structuresSlots = PlayerInstance.PlayerBuild.StructuresSelector.StructuresSlots;
        // int index = 0;
        // //TODO wybrana bron jest jako wybrana - napis na srodku sie zmienia na start
        // foreach (WheelStructureElementUI element in Elements)
        // {
        //     StructureSlot structureSlot = structuresSlots[index];
        //     element.Init(structureSlot);
        //     index++;
        // }
    }
}
