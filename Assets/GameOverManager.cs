using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject gameOverMenu;

    private void Awake()
    {
        player.OnGameOver += Player_OnGameOver;
    }

    private void Player_OnGameOver(object sender, System.EventArgs e)
    {
        StartCoroutine(ShowGameOverMenu());
    }

    IEnumerator ShowGameOverMenu()
    {
        yield return new WaitForSeconds(2f);
        gameOverMenu.SetActive(true);
    }
}
