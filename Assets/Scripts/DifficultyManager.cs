using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private SpawnMathObjects objectSpawner;
    [SerializeField] private PlayerMovement playerMovement;
    // player movement is 400    horizontal 550
    private void Start()
    {
        // easy = 1, normal = 2, hard = 3
        int difficulty = PlayerPrefs.GetInt("difficulty");
        switch (difficulty)
        {
            case 1: // easy
                objectSpawner.SetSpawnZOffset(50);
                playerMovement.SetRunSpeed(400f);
                playerMovement.SetHorizontalSpeed(550f);
                break;

            case 2:  // normal
                objectSpawner.SetSpawnZOffset(45);
                playerMovement.SetRunSpeed(430f);
                playerMovement.SetHorizontalSpeed(580f);
                break;

            case 3:  // hard
                objectSpawner.SetSpawnZOffset(40);
                playerMovement.SetRunSpeed(500f);
                playerMovement.SetHorizontalSpeed(620f);
                break;

            default:
                // set to normal
                objectSpawner.SetSpawnZOffset(45);
                playerMovement.SetRunSpeed(430f);
                playerMovement.SetHorizontalSpeed(580f);
                break;
        }
    }
}
