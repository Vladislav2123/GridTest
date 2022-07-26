using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Grid : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _slotsHolder;
    [SerializeField] private Slot _slotPrefab;
    [SerializeField] private SlotItem _slotItemPrefab;

    [Inject] private DebugMessages _debugMessages;
    [Inject] private Vibration _vibration;
    private RectTransform _rectTransform;

    private float Width => _rectTransform.rect.width;
    private float Height => _rectTransform.rect.height;
    public List<Slot> Slots {get; private set;}
    bool IsEmpty => Slots.Count == 0;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        Slots = new List<Slot>();
    }
    public void Generate(int width, int height)
    {
        TryReset();

        float slotSize = width >= height ? Width / width : Height / height;
        int slotsAmount = width * height;

        _slotsHolder.startAxis = width > height ? GridLayoutGroup.Axis.Horizontal : GridLayoutGroup.Axis.Vertical;
        _slotsHolder.cellSize = Vector2.one * slotSize;

        for(int i = 0; i < slotsAmount; i++)
        {
            Slot newSlot = Instantiate(_slotPrefab, _slotsHolder.transform);
            newSlot.CreateItem(_slotItemPrefab);
            Slots.Add(newSlot);
        }

        _debugMessages.TryShowMessage($"Grid {width}x{height} generated");
        _vibration.TryPlayLightVibration();
    }

    public void TryShuffle()
    {
        if(IsEmpty)
        {
            _debugMessages.TryShowMessage("Grid is empty. Generate it");
            _vibration.TryPlayHeavyVibration();
            return;
        }

        if(Slots.Count == 1)
        {
            _debugMessages.TryShowMessage("There is only one item");
            _vibration.TryPlayHeavyVibration();
            return;
        }

        if(Slots.Find(slot => slot.IsEmpty == false && slot.Item.IsTransiting) != null)
        {
            _debugMessages.TryShowMessage("Grid is already shuffling");
            _vibration.TryPlayHeavyVibration();
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
        
        _debugMessages.TryShowMessage("Shuffling...");
        _vibration.TryPlayLightVibration();
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
