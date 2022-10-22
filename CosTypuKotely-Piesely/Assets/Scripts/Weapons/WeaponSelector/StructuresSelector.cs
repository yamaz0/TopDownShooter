[System.Serializable]
public class StructuresSelector : Selector<StructureSlot>
{
    public void AddStructure(int id)
    {
        StructureInfo info = StructureScriptableObject.Instance.GetStructureInfoById(id);
        AddStructure(info);
    }

    public void AddStructure(StructureInfo info)
    {
        int index = Slots.Count + 1;
        StructureSlot s = new StructureSlot(index);
        // CurrentSlotNumber.Set(index);
        CurrentSlotNumber.SetMax(index);
        s.SetStructure(info);
        Slots.Add(index, s);
    }
}
