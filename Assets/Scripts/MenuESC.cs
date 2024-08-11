using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class MenuESC : MonoBehaviour
{
    public CanvasAnimationSound canvasAnim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasAnim.slowSongInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            SceneManager.LoadScene(0);
        }
    }
}
