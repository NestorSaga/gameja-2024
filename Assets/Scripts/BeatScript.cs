using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScript : MonoBehaviour
{

    public static BeatScript instance;

    public float BPM;
    public float tickInterval, wiggle, currentTimer;
    public float currenTimerMaxAmount, ARcurrenTimerMaxAmount;

    public bool actionable;
    public bool actionableCurrent;
    public bool actionableNext;

    public Movement movement;
    public NPCMovement[] NPCMovementList;

    public int currentBeat = 1;
    public int currentFMODBeat;
    public int lastFMODBeat;

    public bool started;
    public bool inputMade;
    public bool inputRegistered;

    public int currentLevel = 0;

    public GameObject good, bad;
    public ParticleSystem particles;




    //
    float timerTest1, timerTest2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        movement = FindObjectOfType<Movement>();

    }
    private void Start()
    {
        tickInterval = 60 / BPM;
    }

    public void ChangeBeat(int newBeat)
    {

        if (currentFMODBeat != newBeat)
        {
            ResetTick();
            currentTimer = 0;
        }
        currentFMODBeat = newBeat;

    }

    void Update()
    {


        if (started)
        {
   
            if (currentTimer <= wiggle)
            {
                actionable = true; //current
            }else if (currentTimer >= tickInterval - wiggle)
            {
                actionable = true; //next
            }
            else
            {
                actionable = false;
            }
            
            

            /*
            if (currentTimer >= (tickInterval - (wiggle)) && currentTimer <= (tickInterval))
            {
                if (currentBeat != 1)
                {
                    actionable = true;
                    
                }

            }
            else
            {
                Debug.Log("current timer is " + currentTimer  + " and is FALSE");

                actionable = false;
            }
            */
            

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
                    particles.Play();
                    //good.SetActive(true);
                }
            }
            else
            {
                if (inputMade)
                {
                    Debug.Log("CAGASTE");
                    bad.SetActive(true);
                }
            }
            
          
            inputMade = false;
            currentTimer += Time.deltaTime;
        }

        
    }

    void Tick()
    {

    }

    void ResetTick()
    {
        good.SetActive(false);
        bad.SetActive(false);
        currentBeat++;
        movement.NextMovement();
        foreach (var item in NPCMovementList)
        {
            item.NextMovement();
        }
        if (currentBeat >= 4)
        {
            currentBeat = 1;
        }
        //currentTimer = 0;
    }
}
