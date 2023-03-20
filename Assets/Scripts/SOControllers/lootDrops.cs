using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loot", menuName = "ScriptableObjects/LootGenerator", order = 2)]

public class lootDrops : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public lootDrops(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
