using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float jumpForce = 8.0f;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isRunning = true;
            playerAnimator.SetFloat("speed", 1);
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            isRunning = true;
            playerAnimator.SetFloat("speed", -1.0f);
        }

        playerAnimator.SetBool("running", isRunning);
    }

}
