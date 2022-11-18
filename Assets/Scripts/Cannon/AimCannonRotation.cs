using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCannonRotation : MonoBehaviour
{

    //script que se encarga de la rotacion del canyon que apunta al jugador

    //[SerializeField]
    //private Transform target; // indicarle aca a hacia donde mirar, en nuestro caso el jugador o ImageTarget

    private GameObject arCamera;



    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("ARCamera");
    }

    // Update is called once per frame
    void Update()
    {

        // pa donde mirar pisha = posicion obejtivo - nuestra posicion -> direccion pa donde mirar pisha
        Vector3 targetOrientation = arCamera.transform.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.green); // linea al objetivo pa saber si va gucci

        // 3 tipos de orientaciones pisha -> comentar uno y dejar otro o sino AtacarMinion momment
        //orientadengue instantaneo hacia el objetivo
        //transform.rotation = Quaternion.LookRotation(targetOrientation);

        //con efecto de apuntado hacia el objetivo dengue

        //calculamos a que posicion/direccion tiene que mirar
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        // hacemos Slerp que define la rotacion de un punto a a un punto b con tiempo frame por segundo 
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
        
        //orientacion instant tmb pero mas barato
        //transform.LookAt(target);

    }
}
