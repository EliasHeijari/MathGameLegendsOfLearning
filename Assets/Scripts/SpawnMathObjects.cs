using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnMathObjects : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] mathObjectPrefabs;
    [SerializeField] private GameObject[] stopObjectPrefabs;
    [SerializeField] private float spawnZOffset = 10f;
    [SerializeField] private float repeatSpawnTime = 10f;
    [SerializeField] private float startSpawnTime = 9f;
    [SerializeField] private int maxObjCountAtOnce = 30;
    [SerializeField] private float stopObjSpawnCount = 12f;
    private float lastSpawnPosZ;
    List<GameObject> spawnObjList = new List<GameObject>();
    List<GameObject> spawnStopObjList = new List<GameObject>();

    private void Awake()
    {
        InvokeRepeating("SpawnObject", startSpawnTime, repeatSpawnTime);
    }

    private void Update()
    {
        foreach (GameObject obj in spawnObjList.ToList())
        {
            if (obj != null && player != null)
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
        foreach (GameObject obj in spawnStopObjList.ToList())
        {
            if (obj != null)
            {
                float destroyZOffset = 8f;
                if (obj.transform.position.z + destroyZOffset < player.position.z)
                {
                    spawnStopObjList.Remove(obj);
                    Destroy(obj.gameObject);
                }
            }
            else
            {
                spawnStopObjList.Remove(obj);
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

            for (int i = 0; i < stopObjSpawnCount; ++i)
            {
                GameObject stopObjPrefab = stopObjectPrefabs[Random.Range(0, stopObjectPrefabs.Length)];
                float posX = Random.Range(-7.5f, 7.5f);
                float posZ = Random.Range(lastSpawnPosZ - 40, lastSpawnPosZ - 10);
                Vector3 stopObjSpawnPos = new Vector3(posX, 0, posZ);
                GameObject stopObject = Instantiate(stopObjPrefab, stopObjSpawnPos, Quaternion.identity);
                stopObject.transform.position = stopObjSpawnPos;
                spawnStopObjList.Add(stopObject);
            }
        }
    }

    public void SetSpawnZOffset(int value)
    {
        spawnZOffset = value;
    }
}
