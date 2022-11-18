using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    //Agregan punto de inicio de donde la bala saldra.
    public GameObject BalaInicio;
    //Agregan Bala Prefab
    public GameObject BalaPrefab;
    //Agregar Bala Velocidad
    public float BalaVelocidad;


    //Vidas
    public int nVidas;

    public CtrlGame ctrlGame;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;

    // Update is called once per frame


    public void Start()
    {
        nVidas = 3;
    }
    void Update()
    {
        
    }

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bala"))
        {
            recibirdanyo();
        }
    }

    public void disparo()
    {
        //1-Instanciar la BalaPrefab en las posiciones de BalaInicio
        
        GameObject BalaTemporal = Instantiate(BalaPrefab, BalaInicio.transform.position, BalaInicio.transform.rotation) as GameObject;

        //Obtener Rigidbody para agregar Fuerza. 
        Rigidbody rb = BalaTemporal.GetComponentInChildren<Rigidbody>();

        //Agregar la fuerza a la Bala
        rb.AddForce(transform.forward * BalaVelocidad);

        //Debemos Destruir la bala
        Destroy(BalaTemporal, 1.0f);
    }

    public void recibirdanyo()
    {
        nVidas--;
        if (nVidas == 2)
        {
            vida1.SetActive(false);
        }
        if (nVidas == 1)
        {
            vida2.SetActive(false);
        }
        
        if (nVidas == 0)
        {
            vida3.SetActive(false);
            ctrlGame.Death();
        }
    }
}