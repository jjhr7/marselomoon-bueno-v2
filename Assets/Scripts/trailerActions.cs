using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class trailerActions : MonoBehaviour
{
    public VideoPlayer v;

    public long frameEmpiezaVideo;

    // Start is called before the first frame update
    void Start()
    {
        v = this.GetComponent<VideoPlayer>();



    }

    private void OnMouseDown()
    {
        StartCoroutine(playPauseVideo());
    }

    IEnumerator playPauseVideo()
    {
        v.Prepare();
        while (!v.isPrepared)
        {
            yield return null;
        }
        if (v.isPlaying)
        {
            v.Pause();
        }
        else
        {
            v.Play();
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
    }

    // funciones botones UI escena Video
    public void playStopVideo()
    {
        if (v.isPlaying)
        {
            v.Pause();
        }
        else
        {
            v.Play();
        }
    }

    public void restartVideo()
    {
        var frame = frameEmpiezaVideo;
        v.frame = (long)frame;
        v.Play();
    }

    public void haciaAdelante()
    {
        if (v.canStep) // si no funciona quitar esta verga de if angle dies on casetaAngle return F
        {
            v.StepForward();
        }
        else
        {
            restartVideo();
        }
    }
}
