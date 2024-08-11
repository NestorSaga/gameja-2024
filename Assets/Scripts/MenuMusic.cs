using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MenuMusic : MonoBehaviour
{
    [SerializeField]
    public EventReference menuMusic;

    public EventInstance instance;


    private void Start()
    {
        instance = RuntimeManager.CreateInstance(menuMusic);
        instance.start();
        instance.release();
    }

    private void OnDestroy()
    {
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
