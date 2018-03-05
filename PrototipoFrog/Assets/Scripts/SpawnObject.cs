using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public GameObject[] objectToSpawn;
    public float minSpawnTime, maxSpawnTime;
    public bool spawnMovingObjects = false;
    // Update is called once per frame

    private void Start()
    {
        if (spawnMovingObjects)
        {
            SpawnMovingObjects();
        }
        else
        {
            SpawnStaticObjects();
        }
    }
   void SpawnMovingObjects()
    {
        Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], transform.position,Quaternion.identity);
        Invoke("SpawnMovingObjects", Random.Range(minSpawnTime, maxSpawnTime));

    }
    void SpawnStaticObjects()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(objectToSpawn[Random.Range(0,objectToSpawn.Length)], new Vector3(Random.Range(-5,5),0,transform.position.z),Quaternion.identity);
        }
    }
}
