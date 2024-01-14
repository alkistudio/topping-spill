using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingSpawner : MonoBehaviour
{
    public GameObject[] toppingPrefabs;
    public float[] spawnProbabilities;
    public int[] amountBounds; // defines acceptable amounts for scoring
    public bool doSpawn;
    public float spawnFreq;

    // Start is called before the first frame update
    void Start()
    {
        doSpawn = true;

        InvokeRepeating("SpawnTopping", 3f, spawnFreq);
    }

    // Update is called once per frame
    void Update()
    {
        if (!doSpawn)
        {
            CancelInvoke("SpawnTopping");
        }
    }

    void SpawnTopping()
    {
        float randomValue = Random.value;
        float cumulativeProbability = 0f;

        float minX = -30f; // bounding box
        float maxX = 30f;
        float minZ = -15f;
        float maxZ = 15f;
        float planeY = 50;

        for (int i=0; i< toppingPrefabs.Length; i++)
        {
            cumulativeProbability += spawnProbabilities[i];

            if (randomValue <= cumulativeProbability)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), planeY, Random.Range(minZ, maxZ));
                GameObject topping = Instantiate(toppingPrefabs[i], spawnPosition, Quaternion.identity);

                break;
            }
        }
    }
}
