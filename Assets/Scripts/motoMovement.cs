using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class motoMovement : MonoBehaviour
{
    public GameObject[] contactoSuelo;
    public float gravityForce = 12f;
    public float alturaMuelle = 0.65f;
    Rigidbody body;
    int layerMask;
    float avance;
    public float coefAvance = 5.0f;
    public float coefTurbo = 25.0f;
    float giro;
    public float coefGiro = 2.0f;
    private bool turbo;
    private bool turbando;
    float contador;
    public float m_deadZone;
    public GameObject fuego;
    public GameObject fuego2;
    public GameObject fuegoT;
    public GameObject fuegoT2;
    public Vector3 reset;


    void Start()
    {
        body = this.GetComponent<Rigidbody>();
        layerMask = 1 << LayerMask.NameToLayer("Vehicle");
        layerMask = ~layerMask;
        body.centerOfMass = new Vector3(0, -0.5f, 0);
        m_deadZone = 0.2f;
        reset = new Vector3(0, 80, 0);
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        for (int i = 0; i < contactoSuelo.Length; i++)
        {
            if (Physics.Raycast(contactoSuelo[i].transform.position, -Vector3.up, out hit, alturaMuelle, layerMask))
            {
                body.AddForceAtPosition(contactoSuelo[i].transform.up * gravityForce * (((alturaMuelle - hit.distance) / alturaMuelle)), contactoSuelo[i].transform.position);
                
            }
            else
            {
                body.AddForceAtPosition(contactoSuelo[i].transform.up * -gravityForce, contactoSuelo[i].transform.position);
            }
        }
        body.AddForce(transform.forward * avance * coefAvance);
        body.AddRelativeTorque(Vector3.up * giro * coefGiro);

        if (turbando)
        {
            contador += Time.deltaTime;
            body.AddForce(transform.forward * coefTurbo * coefAvance);
            if (contador > 8)
            {
                turbando = false;
                contador = 0;
            }
        }


    }

    private void Update()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.
        Vector2 move = gamepad.rightStick.ReadValue();
        Vector2 move2 = gamepad.leftStick.ReadValue();

        if (move.magnitude > m_deadZone)
        {
            fuego2.SetActive(true);
            fuego.SetActive(true);
        }
        else if (move.magnitude < -m_deadZone)
        {
            fuego.SetActive(false);
            fuego2.SetActive(false);

        }
        else
        {
            fuego.SetActive(false);
            fuego2.SetActive(false);
        }

        if (turbando)
        {
            fuegoT.SetActive(true);
            fuegoT2.SetActive(true);
        } 
        else
        {
            fuegoT.SetActive(false);
            fuegoT2.SetActive(false);
        }
        avance = move.y * coefAvance;
        giro = move2.x * coefGiro;
    }

    void OnDrawGizmos()
    {
        RaycastHit hit;
        for (int i = 0; i < contactoSuelo.Length; i++)
        {
            if (Physics.Raycast(contactoSuelo[i].transform.position, -Vector3.up, out hit, alturaMuelle, layerMask))
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(contactoSuelo[i].transform.position, hit.point);
                Gizmos.DrawSphere(hit.point, 0.05f);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(contactoSuelo[i].transform.position, contactoSuelo[i].transform.position - Vector3.up * alturaMuelle);
            }
        }
    }

    public void tomas_turbin()
    {

        if (!turbando)
        {
            turbando = true;
        }

    }

    public void resetCar()
    {
        body.transform.position = reset;
        body.transform.rotation = Quaternion.identity;
        turbando = false;
        contador = 0;
    }
}
