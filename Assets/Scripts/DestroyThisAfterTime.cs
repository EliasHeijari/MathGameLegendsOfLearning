using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisAfterTime : MonoBehaviour
{
    [SerializeField] private float timeUntilDestroy = 10f;

    private void Awake()
    {
        Destroy(gameObject, timeUntilDestroy);
    }
}
