using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Renderer powerUpRenderer;
    public GameObject Mon;
    ThirdPersonMovement thirdPersonMovement;
    private void Awake() {
        Mon = GameObject.Find("Mon");
        thirdPersonMovement = Mon.GetComponent<ThirdPersonMovement>();

        powerUpRenderer = GetComponent<Renderer>();
    }

   private void OnTriggerEnter(Collider other) {
       // Bomb Power Up
       if(other.tag == "Player" && this.name == "Add_Bomb_Power_Up"){
           ++thirdPersonMovement.bombCounter;
           Destroy(gameObject);  
       }else if(other.tag == "Player" && this.name == "Add_Health_Power_Up"){
           ++thirdPersonMovement.healthCounter;
           Destroy(gameObject); 
       }else if(other.tag == "Player" && this.name == "Add_Speed_Power_Up"){
           thirdPersonMovement.speedCounter += 5;
           Destroy(gameObject); 
       }
   }
    // Update is called once per frame
    void Update()
    {

    
    }
}
