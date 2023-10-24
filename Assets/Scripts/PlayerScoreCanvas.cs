using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreCanvas : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset = new Vector3(0.15f, 1.4f, -0.4f);
    [SerializeField] private TextMeshProUGUI scoreText;
    private Player player;

    private void Start()
    {
        player = playerTransform.GetComponent<Player>();
        player.OnScoreChanged += Player_OnScoreChanged;
    }

    private void Player_OnScoreChanged(object sender, System.EventArgs e)
    {
        // Set Score text
        if (player.Score >= 10) scoreText.text = player.Score.ToString();
        else
        {
            scoreText.text = " " + player.Score.ToString();
        }
    }

    private void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
