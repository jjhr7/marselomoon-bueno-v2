using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasLogica : MonoBehaviour
{



    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void minijuegp()
    {
        SceneManager.LoadScene("MinijuegoScene");
    }
    public void moto()
    {
        SceneManager.LoadScene("MotoScene");
    }
    public void video()
    {
        SceneManager.LoadScene("VideoScene");
    }

    public void instrucciones()
    {
        SceneManager.LoadScene("InstruccionesScene");
    }

    public void home()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
