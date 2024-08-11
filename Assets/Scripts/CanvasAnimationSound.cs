using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class CanvasAnimationSound : MonoBehaviour
{

    public EventReference sound1, sound2, slowSong;

    public EventInstance sound1Instance, sound2Instance, slowSongInstance;

    public FocusRouteReader focusRouteReader;
    public BeatScript beatScript;
    public Movement movement;

    bool started;

    //public List<NPCMovement> NPCMovementList;
    public NPCMovement[] NPCMovementList;



    private void Start()
    {
        beatScript = FindObjectOfType<BeatScript>();
        NPCMovementList = FindObjectsOfType<NPCMovement>();
        BeatScript.instance.NPCMovementList = NPCMovementList;
        int count = 0;
        for (int i = 0; i < OptionsScript.instance.chars.Length; i++)
        {
            if (OptionsScript.instance.selectedChar != i)
            {
                if (NPCMovementList.Length > count)
                {
                    NPCMovementList[count].sprite.sprite = OptionsScript.instance.chars[i];
                    count++;
                }
                
            }                         
        }
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
        /*slowSongInstance = RuntimeManager.CreateInstance(slowSong);
        slowSongInstance.start();
        slowSongInstance.release();
        */
        slowSongInstance = RuntimeManager.CreateInstance(slowSong);
        beatScript.gameObject.GetComponent<BeatTracker>().musicPlayEvent = slowSongInstance;
        beatScript.gameObject.GetComponent<BeatTracker>().StartMusic();
        beatScript.movement = movement;
        beatScript.started = true;
        movement.NextMovement();
        foreach (var item in NPCMovementList)
        {
            item.NextMovement();
        }
        focusRouteReader.NextStepInRoute();
    }

}
