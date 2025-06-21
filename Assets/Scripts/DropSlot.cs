using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private ItemSlot itemSlot;

    void Awake()
    {
        itemSlot = GetComponent<ItemSlot>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem dropped = eventData.pointerDrag?.GetComponent<DraggableItem>();
        if(dropped == null) return;

        ItemSlot originSlot = dropped.originSlot;
        if(originSlot == itemSlot) return;

        if(itemSlot.HasItem)
        {
            Debug.Log($"ItemSlot: Has Item");
            DraggableItem existing = itemSlot.CurrentItem;

            if(existing != null && existing.itemData == dropped.itemData && dropped.itemData.nextLevel != null)
            {
                // Attampt merge
                MergeManager.Instance.Merge(existing, dropped, this.transform);
                originSlot.ClearItem();
                Debug.Log($"DropSlot: Dropped {dropped.name} onto {gameObject.name}. Slot has item: {itemSlot.HasItem}");
            }
            else
            {
                // can't merge - bounce back?
                originSlot.SetItem(dropped);
                Debug.Log($"DropSlot: Unable to drop item, bouncing back");
            }
        }
        else
        {
            // Just drop if slot is empty
            originSlot.ClearItem();
            itemSlot.SetItem(dropped);
            Debug.Log($"ItemSlot: Does Not Have An Item");
        }
    }
}
