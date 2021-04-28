using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour {

    public Button nextBtn;

    public int count = 0;

    public ToggleGroup panel;

    public Toggle tog1, tog2;

    private void Start()
    {
        Button nxtBtn = nextBtn.GetComponent<Button>();
        nxtBtn.onClick.AddListener(SelectToggle);
        tog1.isOn = true;
    }
    public void SelectToggle()
    {
        switch (count)
        {
            case (0):
                Debug.Log("1 has been toggled");
                tog1.isOn = false;
                tog2.isOn = true;
                //count++;
                break;
            case (1):
                Debug.Log("2 has been toggled");
                tog2.isOn = false;
                tog1.isOn = true;
                count = 0;
                break;
                
        }
        /*
        if(tog1.isOn == true)
        {
            Debug.Log("1 has been toggled");
            tog1.isOn = false;
            tog2.isOn = true;
            return;
        }
        /*
        else
        {
            Debug.Log("2 has been toggled");
            tog2.isOn = false;
            tog1.isOn = true;
            return;
        }*/

    }
}
