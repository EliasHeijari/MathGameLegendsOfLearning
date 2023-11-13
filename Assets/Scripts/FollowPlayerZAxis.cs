using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerZAxis : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        if (transform != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
        }
        
    }
}
