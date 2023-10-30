using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDifficulty : MonoBehaviour
{
    [SerializeField] private string keyName = "difficulty";

    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(keyName, difficulty);
    }
}
