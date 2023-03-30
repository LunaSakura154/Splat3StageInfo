using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRotation : MonoBehaviour
{
    [SerializeField] ScreenOrientation orientation;
    private void Update()
    {
        Screen.orientation = orientation;
    }
}
