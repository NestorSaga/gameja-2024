using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSprites : MonoBehaviour
{
    public Color normalSprite, selectedSprite;


    public void SetNormalSprite()
    {
        GetComponent<Button>().image.color = normalSprite;
    }

    public void SetSelectedSprite()
    {
        GetComponent<Button>().image.color = selectedSprite;
    }
}
