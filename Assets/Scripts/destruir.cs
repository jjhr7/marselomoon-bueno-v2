using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {

        GameObject other = collision.gameObject;
        if (other.layer == LayerMask.NameToLayer("enemy"))
        {
            Destroy(other);
            Destroy(gameObject);
        }
    }
}
