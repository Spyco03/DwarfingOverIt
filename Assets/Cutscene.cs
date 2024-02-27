using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{

    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "custscenesecondversion.mp4");
        videoPlayer.Play();
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        
        yield return new WaitForSeconds(37);

        SceneManager.LoadScene("Tutorial");

    }

}
