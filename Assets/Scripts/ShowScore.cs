using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    // Move towards cam and destroy after half a second
    [SerializeField] private Vector3 targetPos = new Vector3(0.67f, 1.435f, 5.18f);
    [SerializeField] private float speed = 13f;
    [SerializeField] private PlayerScoreManager scoreManager;
    [SerializeField] private TextMeshProUGUI scoreShowText;
    private Vector3 oldLocalPos;
    private bool moveTowardsCamera = false;
    private void Awake()
    {
        oldLocalPos = transform.localPosition;
        scoreManager.OnMathObjectTriggered += ScoreManager_OnMathObjectTriggered;
        scoreShowText.enabled = false;
    }

    private void ScoreManager_OnMathObjectTriggered(object sender, EventArgs e)
    {
        scoreShowText.enabled = true;
        moveTowardsCamera = true;
    }

    private void Update()
    {
        if (moveTowardsCamera)
        {
            MoveTowardsCamera();
        }
    }

    private void MoveTowardsCamera()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, speed * Time.deltaTime);
        if (transform.localPosition == targetPos)
        {
            scoreShowText.enabled = false;
            moveTowardsCamera = false;
            transform.localPosition = oldLocalPos;
        }
    }

}
