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

    int firstIndex = 0;
    int secondIndex = 0;

    private void Start()
    {
        startingRot = transform.eulerAngles;
    }

    public void NextMovement()
    {
        if (firstIndex < routeSO.routePoints.Count)
        {
            if (secondIndex < routeSO.routePoints[firstIndex].route.Count)
            {
                if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.UP)
                {
                    Debug.Log("UP");
                    if (transform.position.z <= ZLimit)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), false, false));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.DOWN)
                {
                    Debug.Log("DOWN");
                    if (transform.position.z >= 1)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), false, false));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.LEFT)
                {
                    Debug.Log("LEFT");
                    if (transform.position.x >= 1)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), true, false));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.RIGHT)
                {
                    Debug.Log("RIGHT");
                    if (transform.position.x <= XLimit)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), true, true));
                    }
                }
                else if (routeSO.routePoints[firstIndex].route[secondIndex].direction == RouteStep.dir.STOP)
                {
                    Debug.Log("STOP");
                    if (transform.position.x <= XLimit)
                    {
                        StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z), false, false));
                    }
                }
                secondIndex++;
                if (secondIndex >= routeSO.routePoints[firstIndex].route.Count)
                {
                    secondIndex = 0;
                    firstIndex++;
                    focusRouteReader.NextStepInRoute();
                    if (firstIndex >= routeSO.routePoints.Count)
                    {
                        //finished
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
