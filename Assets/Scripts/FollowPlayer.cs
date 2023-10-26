using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    private void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
