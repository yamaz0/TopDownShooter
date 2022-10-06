[System.Serializable]
public class Slot
{
    int slotNumber;
    public int SlotNumber { get => slotNumber; set => slotNumber = value; }

    public Slot(int number)
    {
        SlotNumber = number;
    }
}
