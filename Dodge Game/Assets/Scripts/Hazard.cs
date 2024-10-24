using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private SpawnRange[] spawnRanges;

    // Start is called before the first frame update
    protected void Start()
    {
        SpawnRange randomRange = spawnRanges[Random.Range(0, spawnRanges.Length)];
        float spawnX = Random.Range(randomRange.min.x, randomRange.max.x);
		float spawnY = Random.Range(randomRange.min.y, randomRange.max.y);
        Vector2 spawnPoint = new Vector2(spawnX, spawnY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public struct SpawnRange
{
    public Vector2 min;
    public Vector2 max;

    public SpawnRange(Vector2 min, Vector2 max)
    {
        this.min = min;
        this.max = max;
    }
}
