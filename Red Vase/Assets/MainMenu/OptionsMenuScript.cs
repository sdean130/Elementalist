using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour {

    public AudioMixer audioMixer;

    public GameObject Main;
    public GameObject Options;

	//working
    public void GoToMainMenu()
    {
        Options.SetActive(false);
        Main.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    //incorrect
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
