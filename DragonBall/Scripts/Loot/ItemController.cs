using Assets.DragonBall.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]public int itemKey;
    public FloatingHealthBar healthBar;
    public HPBar hpBar;
    public Health health;
    [SerializeField] private PlayerWork work;
    public GameObject player;
    private void Awake()
    {
        
    }
    private void Start()
    {
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
                    player.GetComponentInChildren<HPBar>().UpdateHPBar(player.GetComponentInChildren<Health>().currentHealth + 1, player.GetComponentInChildren<Health>().startingHealth);
                    player.GetComponentInChildren<MPBar>().UpdateMPBar(player.GetComponentInChildren<Health>().currentMP + 1, player.GetComponentInChildren<Health>().startingMP);
                    player.GetComponentInChildren<Health>().currentMP += 1;
                    player.GetComponentInChildren<Health>().currentHealth += 1;
                }
                else if(item.GetComponent<ItemController>().itemKey is (int)EnumItem.hoakhi)
                {
                    player.GetComponentInChildren<PlayerWork>().SetMonkeyCheck(true);
                }
                else if(item.GetComponent<ItemController>().itemKey is (int)EnumItem.nr1sao)
                {
                    Debug.Log("NR 1s");
                    //player.GetComponent<Bag>().lootList.Add(item);
                }
                Destroy(item);

            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
