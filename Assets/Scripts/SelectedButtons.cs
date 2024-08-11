using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;

public class SelectedButtons : MonoBehaviour
{

    [SerializeField]
    public EventReference select;

    public EventInstance instance;
    public Button[] buttons;


    public void DeselectAll(int id)
    {

        instance = RuntimeManager.CreateInstance(select);
        instance.start();
        instance.release();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != id)
            {
                buttons[i].GetComponent<ButtonSprites>().SetNormalSprite();
            }
            else
            {
                buttons[i].GetComponent<ButtonSprites>().SetSelectedSprite();
            }
        }
    }
}
