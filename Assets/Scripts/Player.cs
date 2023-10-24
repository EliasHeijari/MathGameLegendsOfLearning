using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int score;
    public event EventHandler OnScoreChanged;
    public int Score { get { return score; } set { score = value; OnScoreChanged?.Invoke(this, EventArgs.Empty); } }



}
