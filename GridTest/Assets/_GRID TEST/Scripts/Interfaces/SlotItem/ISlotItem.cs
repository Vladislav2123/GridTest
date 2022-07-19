public interface ISlotItem
{
    bool IsTransiting {get;}

    Slot Slot {get;}
    void SetSlot(Slot targetSlot);
    void TransitToSlot(Slot targetSlot);
}
