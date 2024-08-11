using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FinalTheatreScript : MonoBehaviour
{
    [SerializeField]
    public EventReference final;

    public EventInstance instance;


    public void PlayFinal()
    {
        instance = RuntimeManager.CreateInstance(final);
        instance.start();
        instance.release();
    }
}
