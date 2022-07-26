using UnityEngine;

[RequireComponent(typeof(ISlotItemValueController))]
public class SlotItem : MonoBehaviour, ISlotItem
{
    private ISlotItemValueController _valueController;
    private SlotItemTransitionAnimation _transitionAnimation;

    public Slot Slot {get; private set;}
    public bool IsTransiting => _transitionAnimation != null ? _transitionAnimation.IsPlaying : false;
    //public bool IsTransiting => false;

    private void Awake()
    {
        _valueController = GetComponent<ISlotItemValueController>();
        _transitionAnimation = GetComponent<SlotItemTransitionAnimation>();
    }

    private void Start()
    {
        _valueController.GenerateRandomValue();
    }

    private void Update()
    {
       // Debug.Log(_transitionAnimation.IsPlaying); 
    }

    public void SetSlot(Slot targetSlot)
    {
        Slot = targetSlot;
        Slot.Item = this;
    }

    public void TransitToSlot(Slot targetSlot)
    {
       SetSlot(targetSlot);
       transform.SetParent(targetSlot.ItemContainer);

       if(_transitionAnimation != null) _transitionAnimation.PlayAnimation();
       else transform.localPosition = Vector3.zero;
    }
}
