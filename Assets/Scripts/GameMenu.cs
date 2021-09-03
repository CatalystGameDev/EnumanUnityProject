using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    Transform Player;
    Transform SpawnPoint;
    ThirdPersonMovement thirdPersonMovement;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Mon").GetComponent<Transform>();
        thirdPersonMovement = Player.GetComponent<ThirdPersonMovement>();
        SpawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
