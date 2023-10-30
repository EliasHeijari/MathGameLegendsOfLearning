using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private SpawnMathObjects objectSpawner;
    private void Start()
    {
        // easy = 1, normal = 2, hard = 3
        int difficulty = PlayerPrefs.GetInt("difficulty");
        switch (difficulty)
        {
            case 1: // easy
                objectSpawner.SetSpawnZOffset(50);
                break;

            case 2:  // normal
                objectSpawner.SetSpawnZOffset(40);
                break;

            case 3:  // hard
                objectSpawner.SetSpawnZOffset(30);
                break;

            default:
                // set to normal
                objectSpawner.SetSpawnZOffset(40);
                break;
        }
    }
}
