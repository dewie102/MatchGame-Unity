using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public DraggableItem CurrentItem { get; private set; }
    public bool HasItem => CurrentItem != null;

    public void SetItem(DraggableItem item)
    {
        CurrentItem = item;
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
    }

    public void ClearItem()
    {
        CurrentItem = null;
    }
}
