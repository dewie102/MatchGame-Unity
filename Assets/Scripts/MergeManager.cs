using System;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance { get; private set; }

    public static event Action<ItemData> OnItemMerged;

    public GameObject itemPrefab;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Merge(DraggableItem a, DraggableItem b, Transform slot)
    {
        ItemData newData = a.itemData.nextLevel;

        Destroy(a.gameObject);
        Destroy(b.gameObject);

        GridManager.Instance.SpawnItemAtSlot(slot.GetComponent<ItemSlot>(), newData);
        RaiseItemMerged(newData);
    }

    public static void RaiseItemMerged(ItemData data)
    {
        OnItemMerged?.Invoke(data);
    }
}
