using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        //This is will load in the scene when the start button in the main menu is clicked
        SceneManager.LoadScene(sceneIndex);
    }
}
