using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;
    public int keyItem;

    public Loot(string lootName, int dropChance, int keyItem)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.keyItem = keyItem;
    }
}