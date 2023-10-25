using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScoreManager : MonoBehaviour
{
    private Player player;
    [SerializeField] private TextMeshProUGUI scoreShowText;
    public event EventHandler OnMathObjectTriggered;


    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MathObject mathObject))
        {
            MathObjectParent mathObjParent = mathObject.GetComponentInParent<MathObjectParent>();
            if (mathObjParent.GetFirstMathObject() == mathObject && mathObjParent.FirstOneWin())
            {
                scoreShowText.color = Color.green;
            }
            else if (mathObjParent.GetFirstMathObject() == mathObject && !mathObjParent.FirstOneWin())
            {
                scoreShowText.color = Color.red;
            }
            else if (mathObjParent.GetFirstMathObject() != mathObject && !mathObjParent.FirstOneWin())
            {
                scoreShowText.color = Color.green;
            }
            else if (mathObjParent.GetFirstMathObject() != mathObject && mathObjParent.FirstOneWin())
            {
                scoreShowText.color = Color.red;
            }
            if (mathObjParent.BothWin())
            {
                scoreShowText.color = Color.green;
            }

            player.Score += (int)mathObject.GetValue();

            scoreShowText.text = mathObject.GetValue().ToString();
            OnMathObjectTriggered?.Invoke(this, EventArgs.Empty);
            Destroy(other.gameObject);
        }
    }
}
