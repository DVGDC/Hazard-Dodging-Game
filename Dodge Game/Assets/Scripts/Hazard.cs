using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hazard : MonoBehaviour
{
    [SerializeField] private SpawnRange[] spawnRanges;

    [SerializeField] private float lifeTime = 5;

    [SerializeField] public float flingMagnitude = 1, upwardsFlingModifier = 1;

    [SerializeField] private UnityEvent spawnEvent, despawnEvent;

    // Start is called before the first frame update
    protected void Start()
    {
        SpawnRange randomRange = spawnRanges[Random.Range(0, spawnRanges.Length)];
        float spawnX = Random.Range(randomRange.min.x, randomRange.max.x);
		float spawnY = Random.Range(randomRange.min.y, randomRange.max.y);
        Vector2 spawnPoint = new Vector2(spawnX, spawnY);
        transform.position = spawnPoint;
        spawnEvent.Invoke();

        Invoke("DespawnHazard", lifeTime);
    }

    private void DespawnHazard()
    {
        despawnEvent.Invoke();
        Destroy(gameObject);
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
