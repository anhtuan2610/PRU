using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] public List<GameObject> lootList;
    void Start()
    {
        lootList = new List<GameObject>();
    }

    void Update()
    {
        
    }
}
