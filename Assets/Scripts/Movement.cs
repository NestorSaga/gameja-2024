using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    bool isMoving, lookingRight;

    public float waitTime;

    public int XLimit, ZLimit;

    public Transform player;

    public Vector3 startingRot;
    public Vector3 currentRot;

    public RouteSO routeSO;

    public FocusRouteReader focusRouteReader;

    public BeatScript beatScript;

    public int firstIndex = 0;
    public int secondIndex = 0;

    public SpriteRenderer sprite;
    public Color shaded, bright;

    public GameObject good, bad;
    public ParticleSystem particles;

    public Animator finalAnimator;
    public Animator theatreAnimator;

    //public Animator 

    private void Start()
    {
        startingRot = transform.eulerAngles;
        beatScript = BeatScript.instance;
        sprite.sprite = OptionsScript.instance.chars[OptionsScript.instance.selectedChar];
        beatScript.particles = particles;
        beatScript.good = good;
        beatScript.bad = bad;
    }
    public bool CheckIfIsFive()
    {
        return routeSO.routePoints[firstIndex].isFive;
    }

    public void NextMovement()
    {


        beatScript.currentDirection = routeSO.routePoints[firstIndex].route[secondIndex].direction;

        if (routeSO.routePoints[firstIndex].route.Count > secondIndex+1)
        {
            beatScript.nextDirection = routeSO.routePoints[firstIndex].route[secondIndex+1].direction;
        }
        else
        {
            if(routeSO.routePoints.Count > firstIndex+1)
            {
                beatScript.nextDirection = routeSO.routePoints[firstIndex+1].route[0].direction;
            }
            else
            {
                beatScript.nextDirection = routeSO.routePoints[firstIndex].route[secondIndex].direction;
            }
        }

        if (firstIndex < routeSO.routePoints.Count)
        {
            if (secondIndex < routeSO.routePoints[firstIndex].route.Count)
            {
                if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.UP)
                {
                    if (transform.position.z <= ZLimit)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), false, false));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.DOWN)
                {
                    if (transform.position.z >= 1)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), false, false));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.LEFT)
                {
                    if (transform.position.x >= 1)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), true, false));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.RIGHT)
                {
                    if (transform.position.x <= XLimit)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), true, true));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.STOP)
                {
                    if (transform.position.x <= XLimit)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z), false, false));
                    }
                }
                secondIndex++;
                sprite.color = shaded;
                if (secondIndex >= routeSO.routePoints[firstIndex].route.Count)
                {
                    secondIndex = 0;
                    firstIndex++;
                    focusRouteReader.readyNext = true;
                    focusRouteReader.lastBeat = beatScript.currentFMODBeat;
                    sprite.color = bright;
                    if (firstIndex >= routeSO.routePoints.Count)
                    {
                        //finished
                        theatreAnimator.SetTrigger("reverse");
                        finalAnimator.SetTrigger("final");
                    }
                }
            }           
        }
    }

    IEnumerator MoveCoroutine(Vector3 pos, bool isHorizontal, bool isRight)
    {
        isMoving = true;
       
        float elapsedTime = 0;

        Vector3 currentPos = transform.position;
        Vector3 rot = player.eulerAngles;
        if (isHorizontal)
        {
            if (!isRight)
            {
                rot = new Vector3(0, 180, 0);
                lookingRight = false;
            }
            else
            {
                rot = startingRot;
                lookingRight = true;
            }
        }
        

        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, pos, (elapsedTime / waitTime));
            if (isHorizontal)
            {
                player.localEulerAngles = Vector3.Lerp(player.localEulerAngles, rot, (elapsedTime / waitTime));
            }           
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        isMoving = false;
        transform.position = pos;
        if (isHorizontal)
        {
            player.localEulerAngles = rot;
            currentRot = player.eulerAngles;
        }

        yield return null;
    }
}
