using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScene : MonoBehaviour {

	public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
