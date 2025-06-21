using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance {get; private set;}

    public GameObject itemPrefab;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Merge(DraggableItem a, DraggableItem b, Transform slot)
    {
        ItemData newData = a.itemData.nextLevel;

        Destroy(a.gameObject);
        Destroy(b.gameObject);

        GameObject newItem = Instantiate(itemPrefab, slot);
        var draggable = newItem.GetComponent<DraggableItem>();
        draggable.SetItem(newData);
        newItem.transform.localPosition = Vector3.zero;
    }
}
