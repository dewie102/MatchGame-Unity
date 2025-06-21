using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject itemPrefab;
    public ItemData[] startingItems;
    public Transform gridParent;

    public int rows = 5;
    public int columns = 5;

    void Start()
    {
        for(int row = 0; row < rows; row++)
        {
            for(int column = 0; column < columns; column++)
            {
                GameObject slot = Instantiate(slotPrefab, gridParent);

                // Randomly spawn an item (optional)
                if(Random.value < 0.4f)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    DraggableItem drag = item.GetComponent<DraggableItem>();
                    drag.SetItem(startingItems[Random.Range(0, startingItems.Length)]);
                }
            }
        }
    }
}
