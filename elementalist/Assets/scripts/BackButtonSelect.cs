using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonSelect : MonoBehaviour {

    public Slider slider;
    // This selects the button when it is referenced 
    public void BackSelect() {
        slider.Select();
	}
}
