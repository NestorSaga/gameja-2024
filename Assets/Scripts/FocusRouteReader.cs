using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusRouteReader : MonoBehaviour
{
    public RouteSO routeSO;

    public GameObject mark;

    public int index;




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index < routeSO.routePoints.Count)
            {
                for (int i = 0; i < routeSO.routePoints[index].route.Count; i++)
                {
               
                    Debug.Log("im in i = " + i + " and count is + " + routeSO.routePoints[index].route.Count);
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
            index++;
        }
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
