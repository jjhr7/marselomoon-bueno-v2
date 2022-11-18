using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    //script de la bala del enemigo

    [SerializeField]
    private float _velocidadBala = 6000;
    [SerializeField]
    private float _vidaBala = 10000;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _vidaBala); // en 5 segundos se destruye la bala
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _velocidadBala); // movimiento hacia la direccion que tiene * la velocidad
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
        Debug.Log("colision ");

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.transform.gameObject.layer.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
        Debug.Log("colision ");
    }
}
