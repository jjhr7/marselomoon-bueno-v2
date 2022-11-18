using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoCannon : MonoBehaviour
{
    //script que hace que dispare misiles esta waina

    [SerializeField]
    public GameObject _bullet; // bala
    [SerializeField]
    private Transform bulletPointInstance;
    [SerializeField]
    private float _timerini = 1.5f; // tiempo de disparo cada 2 segundos
    [SerializeField]
    private float _timerfin = 3f; // tiempo de disparo cada 2 segundos
    [SerializeField]
    private float _timer; // tiempo de disparo cada 2 segundos
    private float timeCount = 0f; // 

    
    private int _counter; //numero de disparos del bucle
    [SerializeField]
    private int _maxCounter; // max de disparon que puede hacer


    // Start is called before the first frame update
    void Start()
    {
        _timer = UnityEngine.Random.Range(_timerini, _timerfin);
        _maxCounter = 20;
        //StartCoroutine(DispararMisiles());
    }

    IEnumerator DispararMisiles() // metodo courutine
    {
        Debug.Log("inicio courutine");
        for(int i= 0; i<_maxCounter; i++) //bucle pa instanciar un num x de misiles
        {
            _counter++; // 1++
            Debug.Log("Bum Bum");
            Debug.Log(i);

            Instantiate(_bullet, bulletPointInstance.position, bulletPointInstance.rotation); //instanciar misil
            yield return new WaitForSeconds(_timer); // espera el tiempo que le ponemos y sale
        }
        Debug.Log("fin courutine");
    }

    // Update is called once per frame
    void Update()
    {
        
        timeCount += Time.deltaTime;
        if (timeCount > _timer) {
            Instantiate(_bullet, bulletPointInstance.position, bulletPointInstance.rotation);
            timeCount = 0;
            _timer = UnityEngine.Random.Range(_timerini, _timerfin);
        }
    }
}
