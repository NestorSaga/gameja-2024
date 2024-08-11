using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonDestroyableOptions : MonoBehaviour
{

    public Slider generalVolumeSlider;

    public SelectedButtons music;

    public void SelectChar(int id)
    {
        OptionsScript.instance.SelectChar(id);
        GetComponent<SelectedButtons>().DeselectAll(id);
    }

    public void SelectMusic(int id)
    {
        OptionsScript.instance.SelectMusic(id);
        music.DeselectAll(id);
    }

    public void OnVolumeChange()
    {
        OptionsScript.instance.OnVolumeChange(generalVolumeSlider.value);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
