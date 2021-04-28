using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public GameObject Main;
    public GameObject Options;
    public GameObject CharacterSelection;

	public void GoToCharacterSelect()
    {
        Main.SetActive(false);
        CharacterSelection.SetActive(true);
    }

    public void GoToOptions()
    {
        Main.SetActive(false);
        Options.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
