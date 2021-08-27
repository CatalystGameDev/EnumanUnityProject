using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public float horizontalMovement;
    public float verticalMovement;
    public float cameraX;
    public float cameraY;
    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        cameraX = Input.GetAxis("Mouse X");
        cameraY = Input.GetAxis("Mouse Y");
    }


}
