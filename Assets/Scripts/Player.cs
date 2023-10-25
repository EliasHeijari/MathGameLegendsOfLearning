using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float score;
    public event EventHandler OnScoreChanged;
    public float Score { get { return score; } set { score = value; OnScoreChanged?.Invoke(this, EventArgs.Empty); } }


}