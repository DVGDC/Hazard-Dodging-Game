using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStorm : Hazard
{
    [SerializeField] private float startDelay;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnXRange;
    [SerializeField] private float spawnYPos;

	[SerializeField] private GameObject rocketPrefab;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        InvokeRepeating("SpawnRocket", startDelay, spawnInterval);
    }

    private void SpawnRocket()
    {
        Transform rocketTransform = Instantiate(rocketPrefab,transform).transform;
        rocketTransform.localPosition = new Vector2(Random.Range(-spawnXRange, spawnXRange), spawnYPos);
    }
}
