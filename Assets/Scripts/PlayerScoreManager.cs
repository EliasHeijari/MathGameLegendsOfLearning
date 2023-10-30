using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    private Player player;
    [SerializeField] private TextMeshProUGUI scoreShowText;
    public event EventHandler OnMathObjectTriggered;


    private void Start()
    {
        player = GetComponent<Player>();
    }

    public float GetScore()
    {
        return player.Score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MathObject mathObject))
        {
            // mathObject Shadder Particle Instantiate and destroy after time
            mathObject.PlayDestroyParticle();

            MathObjectParent mathObjParent = mathObject.GetComponentInParent<MathObjectParent>();
            bool isWinner = false;
            foreach (MathObject winnerObj in mathObjParent.WinnerMathObjects())
            {
                if (mathObject == winnerObj)
                {
                    isWinner = true;
                }
            }
            if (isWinner)
            {
                scoreShowText.color = Color.green;
            }
            else
            {
                scoreShowText.color = Color.red;
                player.DecreaseHealth();
            }
            
            player.Score += (int)mathObject.Value;

            scoreShowText.text = mathObject.Value.ToString();
            OnMathObjectTriggered?.Invoke(this, EventArgs.Empty);
            Destroy(mathObjParent.gameObject);
        }
    }
}
