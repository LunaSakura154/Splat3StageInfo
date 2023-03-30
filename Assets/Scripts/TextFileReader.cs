using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFileReader : MonoBehaviour
{
    public TextAsset textAsset;
    public TextMeshProUGUI textMeshPro;

    private void Update()
    {
        textMeshPro.text= textAsset.text;
    }
}
