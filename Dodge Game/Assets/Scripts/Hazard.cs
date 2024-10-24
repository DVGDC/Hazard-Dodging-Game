using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private SpawnRange[] spawnRanges;

    // Start is called before the first frame update
    protected void Start()
    {
        
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
