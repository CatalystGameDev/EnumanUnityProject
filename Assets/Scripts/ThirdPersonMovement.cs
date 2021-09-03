using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform spawnPoint;
    public Camera cam;
    public float speedCounter = 6f;
    public GameObject bomb;
    public InputManager inputManager;
    CharacterController characterController;
    Animator animatorNick;
    public CameraManager cameraManager;
    Transform cameraObject;
    Rigidbody playerRigidBody;
    public float healthCounter = 5;
    public float bombCounter = 3;
    public float rotationSpeed = 15;
    public float jumpForce = 7;

    private Canvas gameOverscreen;
    public bool isJumping;

    void Awake()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        gameOverscreen = GameObject.Find("GameOver").GetComponent<Canvas>();
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        playerRigidBody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        animatorNick = GetComponent<Animator>();
        cameraObject = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Damage Character when hit
        if (other.gameObject.tag == "Damage") --healthCounter;

        //Check if player falls off the map
        if (other.gameObject.tag == "OutOfBounds") OnPlayerDeath();
    }

    private void OnCollisionEnter(Collision other) {
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if player dies or fall off the map
        if (healthCounter <= 0) OnPlayerDeath();

        //Player Movements WASD
        PlayerMovement();

        //Player Jump
        if (inputManager.jump && !isJumping) PlayerIsJumping();

        //place bomb depending on bomb count
        if (inputManager.placeBomb && bombCounter > 0) PlayerPlaceBomb();

        //Handle Player Camera Movement
        HandlePlayerCamera();

        HandlePlayerAnimation();
    }

    private void PlayerMovement()
    {
        transform.Translate(new Vector3(inputManager.horizontalMovement, 0, inputManager.verticalMovement) * speedCounter * Time.deltaTime);
    }

    private void PlayerIsJumping()
    {
        isJumping = true;
        playerRigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void PlayerPlaceBomb()
    {
        Vector3 bombTargetPosition = transform.position;
        bombTargetPosition.y = bombTargetPosition.y + 0.5f;
        Instantiate(bomb, bombTargetPosition, transform.rotation);
        --bombCounter;
    }

    private void HandlePlayerCamera()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward;
        targetDirection = targetDirection + cameraObject.right * inputManager.cameraX;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }

    private void HandlePlayerAnimation()
    {
        // if moving walk animation will play, else animation will stop
        if (inputManager.horizontalMovement > 0 || inputManager.verticalMovement > 0)
        {
            animatorNick.SetBool("walk", true);
        }
        else
        {
            animatorNick.SetBool("walk", false);
        }
    }

    private void OnPlayerDeath()
    {
        gameOverscreen.enabled = true;
    }
}
