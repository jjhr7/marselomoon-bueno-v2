using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer.Equals("Misil"))
        {
            Destroy(this.gameObject);
        }
        Debug.Log("colision ");

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.transform.gameObject.layer.Equals("Misil"))
        {
            Destroy(this.gameObject);
        }
        Debug.Log("colision ");
    }
}
