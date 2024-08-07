using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class CanvasAnimationSound : MonoBehaviour
{

    public EventReference sound1, sound2, slowSong;

    EventInstance sound1Instance, sound2Instance, slowSongInstance;

    public FocusRouteReader focusRouteReader;
    public BeatScript beatScript;
    public Movement movement;

    bool started;



    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.anyKeyDown && !started)
        {
            GetComponent<Animator>().SetTrigger("Start120");
            started = true;
        }
    }

    public void PlaySound1()
    {
        sound1Instance = RuntimeManager.CreateInstance(sound1);
        sound1Instance.start();
        sound1Instance.release();
    }

    public void PlaySound2()
    {
        sound2Instance = RuntimeManager.CreateInstance(sound2);
        sound2Instance.start();
        sound2Instance.release();
    }

    public void PlaySong1()
    {
        slowSongInstance = RuntimeManager.CreateInstance(slowSong);
        slowSongInstance.start();
        slowSongInstance.release();
        beatScript.started = true;
        movement.NextMovement();
    }

}
