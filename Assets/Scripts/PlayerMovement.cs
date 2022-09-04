using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    private Animator playerAnimator;
    private bool isRunning = false;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(0, 0, vertical);
        movementDirection.Normalize();

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        transform.Translate(movementDirection * (speed * Time.deltaTime));

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        playerAnimator.SetBool("running", isRunning);
    }
}
