using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public float horizontalMovement;
    public float verticalMovement;
    public float cameraX;
    public float cameraY;

    GameMenu gameMenu;
    public bool placeBomb;
    public bool jump;

    public bool pause;

    // Start is called before the first frame update
    void Awake()
    {
        gameMenu = GameObject.Find("GameMenu").GetComponent<GameMenu>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        cameraX = Input.GetAxisRaw("Mouse X");
        cameraY = Input.GetAxisRaw("Mouse Y");
        placeBomb = Input.GetButtonDown("Fire1");
        jump = Input.GetButtonDown("Jump");
        if (Input.GetButtonDown("Cancel")) gameMenu.HandlePauseScreen();
    }
}
