using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    GameMenu  gameMenu;
    public float startingTime = 60;
    public float currentTime = 0;
    public Text GameTimerText;
    // Start is called before the first frame update
    void Start()
    {
        gameMenu = GameObject.Find("GameMenu").GetComponent<GameMenu>();
        GameTimerText = GetComponent<Text>();
        currentTime = startingTime;
    }
// TimeSpan.FromSeconds(timeInSeconds).ToString("mm:ss")
    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        string minSec = string.Format("{0}:{1:00}", (int)currentTime / 60, (int)currentTime % 60);
         GameTimerText.text ="Time : " +  minSec;
        // GameTimerText.text= "Time : " + TimeSpan.FromSeconds(currentTime).ToString(MainMenu:ss");
        if(currentTime <= 0){
            currentTime = 0;
            gameMenu.GameOver();
        }
    }
}
