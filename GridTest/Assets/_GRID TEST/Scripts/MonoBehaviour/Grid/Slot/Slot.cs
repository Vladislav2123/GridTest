using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private Transform _itemContainer;

    private RectTransform _rectTransform;

    public ISlotItem Item {get; set;}
    public bool IsEmpty => Item == null;
    public Transform ItemContainer => _itemContainer;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void CreateItem(SlotItem itemPrefab)
    {
        ISlotItem newItem = Instantiate(itemPrefab, ItemContainer);
        newItem.SetSlot(this);
    }
}
