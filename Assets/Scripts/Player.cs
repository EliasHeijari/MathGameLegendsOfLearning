using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float score;
    public event EventHandler OnScoreChanged;
    private int health;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private Image[] healthImages;
    [SerializeField] private GameObject deathParticlePrefab;
    [SerializeField] private AudioSource dyingAudioSource;
    public event EventHandler OnGameOver;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (transform.position.y <= -15f)
        {
            health = 1;
            DecreaseHealth();
        }
    }

    public int GetHealth() { return health; }
    public void DecreaseHealth()
    {
        --health;
        UpdateHealthUi();
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthUi()
    {
        for (int i = 2; i >= health; --i)
        {
            healthImages[i].color = Color.black;
        }
    }

    private void GameOver()
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);
        GameObject deathParticle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        Destroy(deathParticle, 3f);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        dyingAudioSource.Play();
    }

    public float Score { get { return score; } set { score = value; OnScoreChanged?.Invoke(this, EventArgs.Empty); } }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 350f * Time.deltaTime, ForceMode.Impulse);
        }
    }

}