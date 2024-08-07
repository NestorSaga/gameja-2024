using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScript : MonoBehaviour
{

    public float BPM;
    public float tickInterval, wiggle, currentTimer;

    public bool actionable;

    public Movement movement;

    public int currentBeat = 1;

    public bool started;
    public bool inputMade;
    public bool inputRegistered;

    private void Start()
    {
        tickInterval = 60 / BPM;
    }

    void Update()
    {
        if (started)
        {
            currentTimer += Time.deltaTime;

            if (currentTimer >= (tickInterval - wiggle) && currentTimer <= (tickInterval + wiggle))
            {
                if (currentBeat != 1)
                {
                    actionable = true;
                    Debug.Log("actionable");
                }

            }
            else
            {
                actionable = false;
            }


            if (currentTimer >= tickInterval)
            {
                ResetTick();
            }

            if (Input.GetKeyDown(KeyCode.W) && !inputMade)               
            {
                inputMade = true;
            }else if (Input.GetKeyDown(KeyCode.S) && !inputMade)
            {
                inputMade = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) && !inputMade)
            {
                inputMade = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !inputMade)
            {
                inputMade = true;
            }

            if (actionable)
            {
                if (inputMade)
                {
                    Debug.Log("GOD CABRON");
                }
            }
            else
            {
                if (inputMade)
                {
                    Debug.Log("CAGASTE");
                }
            }

            inputMade = false;
        }

        
    }

    void Tick()
    {

    }

    void ResetTick()
    {
        currentBeat++;
        movement.NextMovement();
        if (currentBeat >= 4)
        {
            currentBeat = 1;
        }
        currentTimer = 0;
    }
}
