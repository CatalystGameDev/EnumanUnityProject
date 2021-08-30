using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExploision : MonoBehaviour
{
    public GameObject Mon;
    ThirdPersonMovement thirdPersonMovement;
    private GameObject explosionParticle;
    private GameObject bomb;
    public float radius = 5f;
    public float power = 5f;
    public float upForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Mon = GameObject.Find("Mon");
        thirdPersonMovement = Mon.GetComponent<ThirdPersonMovement>();
        explosionParticle = this.transform.Find("explosion").gameObject;
        bomb = this.transform.Find("bomb").gameObject;
        Invoke("HandleExplosion", 2);
    }
    private void HandleExplosion()
    {

        explosionParticle.SetActive(true);
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, 0, ForceMode.Impulse);
            }
        }
        bomb.SetActive(false);
        Invoke("DestroyGameObject", 1);
    }
    private void DestroyGameObject()
    {
        ++thirdPersonMovement.bombCounter;
        Destroy(this.gameObject, 1);
    }

}
