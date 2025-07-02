using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public GameObject slotPrefab;
    public GameObject itemPrefab;
    public ItemData[] startingItems;
    public Transform gridParent;

    public int rows = 5;
    public int columns = 5;
    public List<ItemSlot> allSlots;

    public List<ItemSlot> GetFreeSlots() => allSlots.Where(s => !s.HasItem).ToList();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject slot = Instantiate(slotPrefab, gridParent);
                allSlots.Add(slot.GetComponent<ItemSlot>());

                // Randomly spawn an item (optional)
                if (Random.value < 0.4f)
                {
                    SpawnItemAtSlot(slot.GetComponent<ItemSlot>(), GetRandomItemData());
                }
            }
        }
    }

    public ItemData GetRandomItemData()
    {
        ItemData itemData = startingItems[Random.Range(0, startingItems.Length)];

        return itemData;
    }

    public void SpawnRandomItem()
    {
        List<ItemSlot> freeSlots = GetFreeSlots();
        if (freeSlots.Count == 0) return;

        ItemSlot slot = freeSlots[Random.Range(0, freeSlots.Count)];
        ItemData itemData = GetRandomItemData();
        SpawnItemAtSlot(slot, itemData);
    }

    public DraggableItem SpawnItemAtSlot(ItemSlot slot, ItemData data)
    {
        GameObject itemObj = Instantiate(itemPrefab, slot.transform);
        DraggableItem draggable = itemObj.GetComponent<DraggableItem>();

        draggable.SetItemData(data);
        slot.SetItem(draggable);

        itemObj.transform.localPosition = Vector3.zero;

        return draggable;
    }
}
