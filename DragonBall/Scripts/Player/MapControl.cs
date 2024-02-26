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

    public List<GameObject> additionalTerrainChunks; // Mảng chứa các mảnh địa hình mới
    

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

    /*void ChunkChecker()
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

    } */

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
                    if (count <= maxRender)
                    {
                        SpawnChunk(terrainChunks); // Nếu chưa vượt quá số lần maxRender, in ra một map từ terrainChunks
                    }
                    else
                    {
                        SpawnChunk(additionalTerrainChunks); // Nếu đã vượt quá số lần maxRender, in ra một map từ additionalTerrainChunks
                    }
                }
            }
        }

    }



    void SpawnChunk(List<GameObject> chunks)
    {
        if (chunks.Count > 0)
        {
            int rand = Random.Range(0, chunks.Count);
            Instantiate(chunks[rand], noTerrainPosition, Quaternion.identity);
        }
    }

}
