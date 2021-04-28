using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEnemy : MonoBehaviour {
    // calls button functions for each button that is available on screen
    public Button attackBtn;
    public Button previousBtn;
    public Button nextBtn;

    public Toggle enemy1Tog, enemy2Tog, enemy3Tog, enemy4Tog;

    // starts with next button selected
    private void Start()
    {
        enemy1Tog.isOn = true;
        enemy1Tog.Select();
    }

    void CycleEnemy()
    {

    }
}
