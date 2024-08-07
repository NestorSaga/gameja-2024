using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusRouteReader : MonoBehaviour
{
    public RouteSO routeSO;

    public GameObject mark;
    public GameObject focus;

    public int index;

    public bool readyNext;
    public int lastBeat;

    public BeatScript beatScript;



    private void Update()
    {
        if (readyNext && lastBeat != beatScript.currentBeat)
        {
            NextStepInRoute();
            readyNext = false;
        }
    }

    public void NextStepInRoute()
    {
        if (index < routeSO.routePoints.Count)
        {
            focus.SetActive(false);

            for (int i = 0; i < routeSO.routePoints[index].route.Count; i++)
            {
                if (i != routeSO.routePoints[index].route.Count - 1) //is not last
                {
                    RouteMove(routeSO.routePoints[index].route[i].direction, true);
                }
                else
                {
                    RouteMove(routeSO.routePoints[index].route[i].direction, false);

                }
            }
        }
        else
        {
            Debug.Log("all movements finished");
        }
        focus.SetActive(true);
        index++;
    }

    void RouteMove(RouteStep.dir dir, bool spawn)
    {
        if (dir == RouteStep.dir.UP)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        else if (dir == RouteStep.dir.DOWN)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
        else if (dir == RouteStep.dir.RIGHT)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        else if (dir == RouteStep.dir.LEFT)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }


        if (spawn)
        {
            Instantiate(mark, transform.position, Quaternion.identity);
        }
    }
}
