using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningManager : MonoBehaviour
{
    [SerializeField] PlayerScoreManager scoreManager;
    [SerializeField] private float winningScore = 1000f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject winningScreen;
    [SerializeField] private GameObject winningParticlePrefab;
    private bool hasWon = false;
    private void Awake()
    {
        scoreManager.OnMathObjectTriggered += ScoreManager_OnMathObjectTriggered;
    }

    private void ScoreManager_OnMathObjectTriggered(object sender, System.EventArgs e)
    {
        if (scoreManager.GetScore() > winningScore && !hasWon)
        {
            hasWon = true;
            // Won game
            StartCoroutine(ShowWinningScreen());
        }
    }

    IEnumerator ShowWinningScreen()
    {
        winningScreen.SetActive(true);
        GameObject winningParticle = Instantiate(winningParticlePrefab, playerTransform.position, Quaternion.identity);
        Destroy(winningParticle, 2f);
        yield return new WaitForSeconds(3f);
        winningScreen.SetActive(false);
    }
}
