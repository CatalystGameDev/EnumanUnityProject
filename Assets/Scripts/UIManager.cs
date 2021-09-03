using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    ThirdPersonMovement thirdPersonMovement;
    public Text bombCountText, healthCountText,speedCounterText;
    // Start is called before the first frame update
    void Start()
    {
        healthCountText = GameObject.Find("txtHealthCount").GetComponent<Text>();
        bombCountText = GameObject.Find("txtBombCount").GetComponent<Text>();       
        speedCounterText = GameObject.Find("txtSpeedCount").GetComponent<Text>();
        thirdPersonMovement = GameObject.Find("Mon").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        healthCountText.text = "HP : " + thirdPersonMovement.healthCounter;
        bombCountText.text = "Bomb Count : " + thirdPersonMovement.bombCounter;
        speedCounterText.text = "Speed : " + thirdPersonMovement.speedCounter;
    }
}
