using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void OnClick()
    {
       

        if (OptionsScript.instance.selectedMusic == 0)
        {
            SceneManager.LoadScene(1);
            BeatScript.instance.BPM = 120;
            BeatScript.instance.wiggle = .14f;

        }
        else
        {
            SceneManager.LoadScene(2);
            BeatScript.instance.BPM = 200;
            BeatScript.instance.wiggle = .08f;
        }
    }
}
