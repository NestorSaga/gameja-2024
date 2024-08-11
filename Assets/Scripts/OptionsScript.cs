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
        
    }

    public void SelectMusic(int id)
    {
        selectedMusic = id;
        
    }

    public void OnVolumeChange(float value)
    {
        SetBusVolume(generalVolumePath, value);
    }

    public void SetBusVolume(string busName, float volume)
    {
        Bus bus;

        bus = RuntimeManager.GetBus(busName);
        bus.setVolume(volume);

    }
}
