using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScript : MonoBehaviour
{

    public float BPM;
    public float tickInterval, wiggle, currentTimer;

    public bool actionable;

    private void Start()
    {
        tickInterval = 60 / BPM;
    }

    void Update()
    {
        currentTimer += Time.deltaTime;

        if (currentTimer >= tickInterval - wiggle && currentTimer <= tickInterval + wiggle)
        {
            actionable = true;
            Debug.Log("actionable");
        }
        else
        {
            actionable = false;
        }


        if (currentTimer >= tickInterval)
        {
            ResetTick();
        }
    }

    void Tick()
    {

    }

    void ResetTick()
    {
        currentTimer = 0;
    }
}
