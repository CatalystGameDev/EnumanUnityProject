using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformManager : MonoBehaviour
{

    Vector3 scale;
    private void OnCollisionEnter(Collision other)
    {
        scale = other.transform.localScale;
        GameObject emptyObject = new GameObject();
        emptyObject.transform.parent = transform;
        other.gameObject.transform.parent = emptyObject.transform;
    }


    private void OnCollisionExit(Collision other)
    {
        other.gameObject.transform.parent = null;
        foreach (Transform child in transform)
        {
            if (child.childCount <= 0) GameObject.Destroy(child.gameObject);
        }
    }
}
