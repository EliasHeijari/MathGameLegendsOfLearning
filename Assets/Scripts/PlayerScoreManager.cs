using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScoreManager : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void AddToScore(int amount)
    {
        player.Score += amount;
    }

    public void MultiplyScore(int amount)
    {
        player.Score *= amount;
    }

    public void DivideScore(int amount)
    {
        player.Score /= amount;
    }

    public void MinusFromScore(int amount)
    {
        player.Score -= amount;
    }
}
