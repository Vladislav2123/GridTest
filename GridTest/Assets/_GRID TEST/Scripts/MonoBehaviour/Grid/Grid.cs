using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _slotsHolder;
    [SerializeField] private Slot _slotPrefab;
    [SerializeField] private SlotItem _slotItemPrefab;

    private RectTransform _rectTransform;

    private float Width => _rectTransform.rect.width;
    private float Height => _rectTransform.rect.height;
    public List<Slot> Slots {get; private set;}
    bool IsEmpty => Slots.Count == 0;
    private DebugMessages DebugMessages => ServiceLocator.Instance.DebugMessages;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        Slots = new List<Slot>();
    }
    public void Generate(int width, int height)
    {
        TryReset();

        Debug.LogWarning($"==== GRID GENERATING: {width}x{height} ====");

        float slotSize = width >= height ? Width / width : Height / height;
        int slotsAmount = width * height;

        Debug.Log($"Slots Amount: {slotsAmount}");
        Debug.Log($"Slot Size: {slotSize}");

        _slotsHolder.startAxis = width > height ? GridLayoutGroup.Axis.Horizontal : GridLayoutGroup.Axis.Vertical;
        _slotsHolder.cellSize = Vector2.one * slotSize;

        for(int i = 0; i < slotsAmount; i++)
        {
            Slot newSlot = Instantiate(_slotPrefab, _slotsHolder.transform);
            newSlot.CreateItem(_slotItemPrefab);
            Slots.Add(newSlot);
        }

        Debug.LogWarning($"Grid Generated");
        DebugMessages.TryShowMessage($"Grid {width}x{height} generated");
    }

    public void TryShuffle()
    {
        if(IsEmpty)
        {
            Debug.LogWarning($"Grid.TryShuffle: Grid Is Empty");
            DebugMessages.TryShowMessage("Grid is empty. Generate it");
            return;
        }

        if(Slots.Count == 1)
        {
            DebugMessages.TryShowMessage("There is only one item");
            return;
        }

        if(Slots.Find(slot => slot.IsEmpty == false && slot.Item.IsTransiting) != null)
        {
            Debug.Log("Grid.TryShuffle: Transition is not completed");
            DebugMessages.TryShowMessage("Grid is already shuffling");
            return;
        }

        List<ISlotItem> slotsItems = new List<ISlotItem>(Slots.Count);
        foreach(Slot slot in Slots)
        {
            slotsItems.Add(slot.Item);
            slot.Item = null;
        }

        foreach(SlotItem item in slotsItems)
        {
            List<Slot> availableSlots = Slots.FindAll(slot => item.Slot != slot && slot.IsEmpty);
            if(availableSlots.Count == 0)
            {
                Slot emptySlot = Slots.Find(slot => slot.IsEmpty);
                item.TransitToSlot(emptySlot);
                continue;
            }
            int randomSlotIndex = Random.Range(0, availableSlots.Count);
            Slot randomSlot = availableSlots[randomSlotIndex];
            item.TransitToSlot(randomSlot);
        }
        
        DebugMessages.TryShowMessage("Shuffling...");
    }

    public void TryReset()
    {
        if(IsEmpty)
        {
            Debug.LogWarning($"Grid.TryReset: Grid Is Empty");
            return;
        }

        Slot[] copiedSlots = Slots.ToArray();
        for(int i = 0; i < copiedSlots.Length; i++) Destroy(copiedSlots[i].gameObject);
        Slots.Clear();
    }
}
