using System.Collections.Generic;
using UnityEngine;
// using Zenject;
[System.Serializable]
public class Selector<T> where T : Slot
{
    public const int SLOT_MAX_COUNT = 10;

    [SerializeReference]
    private Dictionary<int, T> slots = new Dictionary<int, T>();
    public Dictionary<int, T> Slots { get => slots; set => slots = value; }

    public Counter CurrentSlotNumber { get; set; } = new Counter(1, 1, 1);

    // public void Init()
    // {
    //     Slots = new Dictionary<int, T>(SLOT_COUNT);

    //     for (int i = 0; i < SLOT_COUNT; i++)
    //     {
    //         Slots.Add((T)System.Activator.CreateInstance(typeof(T), i));
    //     }
    // }

    public T NextSlot()
    {
        CurrentSlotNumber.Increase();
        return Slots[CurrentSlotNumber.Value];
    }

    public T PreviousSlot()
    {
        CurrentSlotNumber.Decrease();
        return Slots[CurrentSlotNumber.Value];
    }

    public T SetSlot(int slotIndex)
    {
        T t = null;
        if (slotIndex == 0) slotIndex = SLOT_MAX_COUNT;//0 jest ostatnim slotem
        if (Slots.ContainsKey(slotIndex))
        {
            CurrentSlotNumber.Set(slotIndex);
            t = Slots[CurrentSlotNumber.Value];
        }

        return t;
    }


}
