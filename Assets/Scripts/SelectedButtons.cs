using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButtons : MonoBehaviour
{
    public Button[] buttons;


    public void DeselectAll(int id)
    {
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
