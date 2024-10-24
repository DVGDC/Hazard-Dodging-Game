using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] hazards;

    [SerializeField] private float startDelay;

    [SerializeField] private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("startSpawning", startDelay);
    }

    private void startSpawning()
    {
        StartCoroutine(spawnHazard());
    }

    private IEnumerator spawnHazard()
    {
        Instantiate(hazards[Random.Range(0, hazards.Length)]);
        yield return new WaitForSeconds(spawnInterval);
		StartCoroutine(spawnHazard());
	}
}
