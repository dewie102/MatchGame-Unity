using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    void OnEnable() => MergeManager.OnItemMerged += HandleItemUnlocked;
    void OnDisable() => MergeManager.OnItemMerged -= HandleItemUnlocked;

    List<ItemData> unlockedItems = new();


    void HandleItemUnlocked(ItemData itemData)
    {
        if (!unlockedItems.Contains(itemData))
        {
            unlockedItems.Add(itemData);
            Debug.Log($"New Item Unlocked! {itemData.itemName}");
            // Do other unlock things like show popup or something
        }
    }
}