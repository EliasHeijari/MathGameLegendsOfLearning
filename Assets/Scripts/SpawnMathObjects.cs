using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnMathObjects : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] mathObjectPrefabs;
    [SerializeField] private float spawnZOffset = 10f;
    [SerializeField] private float repeatSpawnTime = 10f;
    [SerializeField] private float startSpawnTime = 9f;
    [SerializeField] private int maxObjCountAtOnce = 30;
    private float lastSpawnPosZ;
    List<GameObject> spawnObjList = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnObject", startSpawnTime, repeatSpawnTime);
    }

    private void Update()
    {
        foreach (GameObject obj in spawnObjList.ToList())
        {
            if (obj != null)
            {
                if (obj.transform.position.z < player.position.z)
                {
                    spawnObjList.Remove(obj);
                    Destroy(obj.gameObject);
                }
            }
            else
            {
                spawnObjList.Remove(obj);
            }
        }
    }

    private void SpawnObject()
    {
        if (spawnObjList.Count + 1 <= maxObjCountAtOnce)
        {
            GameObject mathObjectPrefab = mathObjectPrefabs[Random.Range(0, mathObjectPrefabs.Length)];
            Vector3 spawnPos = new Vector3(mathObjectPrefab.transform.position.x, mathObjectPrefab.transform.position.y, lastSpawnPosZ + spawnZOffset);
            lastSpawnPosZ = spawnPos.z;
            GameObject mathObject = Instantiate(mathObjectPrefab, spawnPos, Quaternion.identity);
            spawnObjList.Add(mathObject);
        }
    }
}
