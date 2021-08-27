using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Camera cam;
    public Transform cameraPivot; //the object the camera uses to pivot
    public Transform targetTransform; //the object the camera will follow
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public float lookAngle; // camera looking up and down
    public float pivotAngle; // camera looking left and right
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 1f;
    public float cameraPivotSpeed = 1f;
    public float minimumPivotAngle = -35;
    public float maximumPivotAngle = 35;
    public Vector3 cameraRotation;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        targetTransform = FindObjectOfType<ThirdPersonMovement>().transform;
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;


        lookAngle = lookAngle + (inputManager.cameraX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;


    }
}
