using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject PortraitUI;
    [SerializeField] GameObject LandscapeUI;
    private void Start()
    {
        Screen.fullScreen = false;
    }

    private void Update()
    {
        if(Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            PortraitUI.SetActive(true);
            LandscapeUI.SetActive(false);
        }
        else
        {
            PortraitUI.SetActive(false);
            LandscapeUI.SetActive(true);
        }
    }
}
