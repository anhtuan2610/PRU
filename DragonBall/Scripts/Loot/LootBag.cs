using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class LootBag : MonoBehaviour
{

    public GameObject dropItemPrefab;
    public List<Loot> lootList = new List<Loot>();
    private void Update()
    {
        
    }

    Loot GetDroppedItem()
    {
        //int randomNumber = Random.Range(1, 101);
        int randomNumber = 10;
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);

            }
        }
        if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }

        

        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObect = Instantiate(dropItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObect.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            lootGameObect.AddComponent<BoxCollider2D>(); 
            lootGameObect.GetComponent<Rigidbody2D>().gravityScale = 1f;
            lootGameObect.GetComponent<ItemController>().itemKey = droppedItem.keyItem;
            Vector2 dropDirection = new Vector2(0,0);
            lootGameObect.GetComponent<Rigidbody2D>().AddForce(dropDirection, ForceMode2D.Force);

        }



    }

}