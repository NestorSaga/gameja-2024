using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutoScript : MonoBehaviour
{

    public GameObject tuto;

    public bool isActive;
    public void OnClick()
    {
        if (isActive)
        {
            tuto.SetActive(false);
            isActive = false;
        }
        else
        {
            tuto.SetActive(true);
            isActive = true;
        }
        
    }
}
