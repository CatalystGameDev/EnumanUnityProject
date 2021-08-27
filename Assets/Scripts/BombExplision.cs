using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplision : MonoBehaviour
{

    private GameObject explosionParticle;
    private GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        explosionParticle = this.transform.Find("explosion").gameObject;
        bomb = this.transform.Find("bomb").gameObject;
        Invoke("HandleExplosion", 2);
    }
    private void HandleExplosion()
    {
        explosionParticle.SetActive(true);
        bomb.SetActive(false);
        Invoke("DestroyGameObject", 1);
    }
    private void DestroyGameObject()
    {
        Destroy(this.gameObject, 1);
    }

}
