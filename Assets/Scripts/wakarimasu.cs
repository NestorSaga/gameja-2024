using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;
using TMPro;

public class wakarimasu : MonoBehaviour
{
    [SerializeField]
    public EventReference wakariTriste, wakariHappy, wakariCum, wakariNormal, finishSong;

    public EventInstance instance, finishSongInstance;

    public int totalPointsSong;

    public TMP_Text score;

    public int scoreS, scoreA, scoreB, scoreC;


    public void PlayWakari()
    {
        //BeatScript.instance.points;
        int points = BeatScript.instance.buenus - BeatScript.instance.malus;

        
        if (BeatScript.instance.buenus - BeatScript.instance.malus >= scoreS)
        {
            PlayCum();
            score.text = points + "p. \n PERFECT";

        }
        else if (BeatScript.instance.buenus - BeatScript.instance.malus >= scoreA)
        {
            PlayHappy();
            score.text = points + "p. \n GREAT";
        }
        else if (BeatScript.instance.buenus - BeatScript.instance.malus >= scoreB)
        {
            PlayNormal();
            score.text = points + "p. \n GOOD";
        }
        else
        {
            PlaySad();
            score.text = points + "p. \n TRY AGAIN";
        }

    }

    public void PlayFinishSong()
    {
        instance = RuntimeManager.CreateInstance(finishSong);
        instance.start();
        instance.release();
    }


    public void PlaySad()
    {
        instance = RuntimeManager.CreateInstance(wakariTriste);
        instance.start();
        instance.release();
    }
    public void PlayHappy()
    {
        instance = RuntimeManager.CreateInstance(wakariHappy);
        instance.start();
        instance.release();
    }
    public void PlayNormal()
    {
        instance = RuntimeManager.CreateInstance(wakariNormal);
        instance.start();
        instance.release();
    }
    public void PlayCum()
    {
        instance = RuntimeManager.CreateInstance(wakariCum);
        instance.start();
        instance.release();
    }

}
