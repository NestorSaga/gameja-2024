using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class OptionsScript : MonoBehaviour
{

    public static OptionsScript instance;

    public Sprite[] chars;
    public bool[] charSelected;

    public int selectedChar = 0;
    public int selectedMusic = 0;

    [SerializeField] private string generalVolumePath;

    public Slider generalVolumeSlider;

    public SelectedButtons music;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SelectChar(int id)
    {
        selectedChar = id;
        GetComponent<SelectedButtons>().DeselectAll(id);
    }

    public void SelectMusic(int id)
    {
        selectedMusic = id;
        music.DeselectAll(id);
    }

    public void OnVolumeChange()
    {
        SetBusVolume(generalVolumePath, generalVolumeSlider.value);
    }

    public void SetBusVolume(string busName, float volume)
    {
        Bus bus;

        bus = RuntimeManager.GetBus(busName);
        bus.setVolume(volume);

    }
}
