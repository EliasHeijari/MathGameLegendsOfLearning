using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScoreManager : MonoBehaviour
{
    private Player player;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    public event EventHandler OnMathObjectTriggered;


    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MathObject mathObject))
        {
            player.Score += mathObject.GetValue();

            textMeshProUGUI.text = mathObject.GetValue().ToString();
            OnMathObjectTriggered?.Invoke(this, EventArgs.Empty);
            Destroy(other.gameObject);
        }
    }
}
