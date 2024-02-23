using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public LayerMask terrainMask;
    private Vector3 noTerrainPosition;
    public GameObject currentChunk;

    int count = 0;
    public int maxRender;

    void Start()
    {

    }

    void Update()
    {
        if (count <= maxRender)
        {
            ChunkChecker();
        }
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");

        if (player != null) 
        {
            if (horizontal > 0)
            {
                
                if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
                {
                    noTerrainPosition = currentChunk.transform.Find("Right").position;
                    count++;
                    SpawnChunk();
                }
            }
        }

    } 



    void SpawnChunk()
    {
        if (terrainChunks.Count > 0)
        {
            int rand = Random.Range(0, terrainChunks.Count);
            Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        }
    }   
}
