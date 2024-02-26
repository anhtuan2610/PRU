using Assets.DragonBall.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]public int itemKey;
    [SerializeField] FloatingHealthBar healthBar;
    public GameObject player;
    private void Awake()
    {
        
    }
    private void Start()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject item = GameObject.FindGameObjectWithTag("Item");
            if (item != null)
            {
                if (item.GetComponent<ItemController>().itemKey is (int)EnumItem.dauthan or
                    (int)EnumItem.duiga)
                {
                    Debug.Log("An dau than");
                }
                else if(item.GetComponent<ItemController>().itemKey is (int)EnumItem.hoakhi)
                {
                    player.GetComponent<Bag>().lootList.Add(item);
                }
                else if(item.GetComponent<ItemController>().itemKey is (int)EnumItem.nr1sao)
                {
                    Debug.Log("NR 1s");
                    player.GetComponent<Bag>().lootList.Add(item);
                }
                Destroy(item);

            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
