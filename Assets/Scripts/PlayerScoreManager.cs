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
    [SerializeField] private AudioClip glassShadderClip;
    [SerializeField] private AudioClip scoreClip;
    [SerializeField] private AudioClip wrongClip;
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;


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
            audioSource1.clip = glassShadderClip;
            audioSource1.Play();

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
                audioSource2.clip = scoreClip;
                audioSource2.Play();
            }
            else
            {
                scoreShowText.color = Color.red;
                player.DecreaseHealth();
                audioSource2.clip = wrongClip;
                audioSource2.Play();
            }
            
            player.Score += (int)mathObject.Value;

            scoreShowText.text = mathObject.Value.ToString();
            OnMathObjectTriggered?.Invoke(this, EventArgs.Empty);
            Destroy(mathObjParent.gameObject);
        }
        else if (other.TryGetComponent(out KillCube killCube))
        {
            player.DecreaseHealth();
            killCube.PlayDestroyParticle();
            Destroy(other.gameObject);
        }
    }
}
