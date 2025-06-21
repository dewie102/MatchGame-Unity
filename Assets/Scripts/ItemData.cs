using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "MergeGame/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int level;
    public ItemData nextLevel; // The result of merging two of this item
}
