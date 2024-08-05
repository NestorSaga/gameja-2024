using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    bool isMoving;

    public float waitTime;

    public int XLimit, ZLimit;

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (transform.position.z <= ZLimit)
                {
                    StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z +1)));
                }
            }else if (Input.GetKeyDown(KeyCode.S))
            {
                if (transform.position.z >= 1)
                {
                    StartCoroutine(MoveCoroutine(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1)));
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (transform.position.x >= 1)
                {
                    StartCoroutine(MoveCoroutine(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z)));
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.position.x <= XLimit)
                {
                    StartCoroutine(MoveCoroutine(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z)));
                }
            }
        }

        
    }

    IEnumerator MoveCoroutine(Vector3 pos)
    {
        isMoving = true;
       
        float elapsedTime = 0;

        Vector3 currentPos = transform.position;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, pos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        isMoving = false;
        transform.position = pos;
        yield return null;
    }
}
