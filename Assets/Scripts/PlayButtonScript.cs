using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class PlayButtonScript : MonoBehaviour
{

    [SerializeField]
    public EventReference select;

    public EventInstance instance;
    public void OnClick()
    {

        instance = RuntimeManager.CreateInstance(select);
        instance.start();
        instance.release();

        if (OptionsScript.instance.selectedMusic == 0)
        {
            SceneManager.LoadScene(1);
            BeatScript.instance.BPM = 120;
            BeatScript.instance.wiggle = .14f;

        }
        else
        {
            SceneManager.LoadScene(2);
            BeatScript.instance.BPM = 200;
            BeatScript.instance.wiggle = .08f;
        }
    }
}
