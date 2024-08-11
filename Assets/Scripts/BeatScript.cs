using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

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

    public RouteStep.dir currentDirection, nextDirection, inputDirection;

    public int buenus;
    public int malus;

    [SerializeField]
    public EventReference buenusEvent, malusEvent;

    public EventInstance buenusInstance, malusInstance;


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

            Debug.Log("RESET current dir is " + movement.routeSO.routePoints[movement.firstIndex].route[movement.secondIndex].direction);
        }
        currentFMODBeat = newBeat;

    }

    void Update()
    {


        if (started)
        {
            inputMade = false;

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

            if (currentFMODBeat == 1)
            {
                if (movement.routeSO.routePoints[movement.firstIndex].isFive)
                {
                    actionable = true;
                }
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
                inputDirection = RouteStep.dir.UP;
            }else if (Input.GetKeyDown(KeyCode.S) && !inputMade)
            {
                inputMade = true;
                inputDirection = RouteStep.dir.DOWN;
            }
            else if (Input.GetKeyDown(KeyCode.A) && !inputMade)
            {
                inputMade = true;
                inputDirection = RouteStep.dir.LEFT;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !inputMade)
            {
                inputMade = true;
                inputDirection = RouteStep.dir.RIGHT;
            }

            
            if (actionable)
            {
                if (inputMade)
                {
                    if (inputDirection == currentDirection || inputDirection == nextDirection)
                    {
                        Debug.Log("GOD CABRON");
                        buenus++;
                        //particles.Play();
                        good.SetActive(true);
                        PlayBuenusSound();
                        StartCoroutine(BuenusMalusShow());
                    }
                    else
                    {
                        Debug.Log("CAGASTE");
                        malus++;
                        bad.SetActive(true);
                        PlayMalusSound();
                        StartCoroutine(BuenusMalusShow());
                    }

                }
            }
            else
            {
                if (inputMade)
                {
                    Debug.Log("CAGASTE");
                    malus++;
                    bad.SetActive(true);
                    PlayMalusSound();
                    StartCoroutine(BuenusMalusShow());
                }
            }
            
          

            currentTimer += Time.deltaTime;
        }

        
    }

    void Tick()
    {

    }

    void PlayBuenusSound()
    {
        if (buenusInstance.isValid())
        {
            buenusInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        buenusInstance = RuntimeManager.CreateInstance(buenusEvent);
        buenusInstance.start();
        buenusInstance.release();
    }

    void PlayMalusSound()
    {
        if (malusInstance.isValid())
        {
            malusInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        malusInstance = RuntimeManager.CreateInstance(malusEvent);
        malusInstance.start();
        malusInstance.release();
    }

    void ResetTick()
    {

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

    IEnumerator BuenusMalusShow()
    {
        yield return new WaitForSeconds(.2f);
        good.SetActive(false);
        bad.SetActive(false);
    }
}
