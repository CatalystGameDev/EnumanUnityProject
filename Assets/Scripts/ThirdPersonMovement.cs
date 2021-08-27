using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public Camera cam;
    public float speed = 6f;
    public GameObject bomb;
    public InputManager inputManager;
    CharacterController characterController;
    Animator animatorNick;
    public CameraManager cameraManager;
    Transform cameraObject;

    public float rotationSpeed = 15;
    // Start is called before the first frame update
    void Awake()
    {
        

        // inputManager = FindObjectOfType<InputManager>();
        characterController = GetComponent<CharacterController>();
        animatorNick = GetComponent<Animator>();
        cameraObject = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.placeBomb)
        {
            Vector3 bombTargetPosition = transform.position;
            bombTargetPosition.y = bombTargetPosition.y + 0.5f;
            Instantiate(bomb, bombTargetPosition, transform.rotation);
            Debug.Log(inputManager.placeBomb);
        }

        Vector3 movement = new Vector3(inputManager.horizontalMovement, 0, inputManager.verticalMovement);

        if (inputManager.horizontalMovement > 0 || inputManager.verticalMovement > 0)
        {
            animatorNick.SetBool("walk", true);
        }
        else
        {
            animatorNick.SetBool("walk", false);
        }

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

        Vector3 rotatedMovement = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * movement;

        characterController.Move(rotatedMovement * speed * Time.deltaTime);
    }
}
