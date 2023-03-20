using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<lootDrops> lootList = new List<lootDrops>();

    lootDrops GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<lootDrops> possibleItems = new List<lootDrops>();
        foreach (lootDrops item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            lootDrops droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        lootDrops droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            lootGameObject.AddComponent<CollisionDetector>();

        }
    }
}
