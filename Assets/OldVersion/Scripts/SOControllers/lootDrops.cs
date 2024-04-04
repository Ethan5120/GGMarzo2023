using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
