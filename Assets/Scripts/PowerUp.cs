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

    // Start is called before the first frame update
   private void OnTriggerEnter(Collider other) {
       if(other.tag == "Player"){
           ++thirdPersonMovement.bombCounter;
           Destroy(this.gameObject);  

       }
   }

    // Update is called once per frame
    void Update()
    {

    
    }
}
