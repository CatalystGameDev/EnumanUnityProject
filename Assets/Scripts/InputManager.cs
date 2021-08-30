using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public float horizontalMovement;
    public float verticalMovement;
    public float cameraX;
    public float cameraY;

    public bool placeBomb;
    // Start is called before the first frame update
    void Awake()
    {

    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        cameraX = Input.GetAxisRaw("Mouse X");
        cameraY = Input.GetAxisRaw("Mouse Y");
        // if(Input.GetButtonDown("Place Bomb") && placeBomb == false){
            
        // }else if(Input.GetButtonUp("Place Bomb")){
        //     placeBomb = false;
        // }
        placeBomb = Input.GetButtonDown("Place Bomb");
    }


}
