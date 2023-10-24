using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameInputs gameInput;
    private Rigidbody rb;

    [Space(5)]

    [Header("Movement")]
    [SerializeField] private float horizontalSpeed = 550f;
    [SerializeField] private float runSpeed = 300f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = gameInput.HorizontalInput();

        Vector3 movementDirHorizontal = new Vector3(horizontalInput, 0, 0);

        // Horizontal Movement
        rb.AddForce(movementDirHorizontal * horizontalSpeed * Time.deltaTime);

        // Forward Movement added to velocity
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, runSpeed * Time.deltaTime);

    }

}
