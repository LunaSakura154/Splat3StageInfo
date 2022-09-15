using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInfo : MonoBehaviour
{
    [SerializeField] Splatoon3ink ink;
    [Header("Images")]
    [SerializeField] UnityEngine.UI.Image reg0;
    [SerializeField] UnityEngine.UI.Image reg1;
    [SerializeField] UnityEngine.UI.Image ser0;
    [SerializeField] UnityEngine.UI.Image ser1;
    [SerializeField] UnityEngine.UI.Image op0;
    [SerializeField] UnityEngine.UI.Image op1;
    [SerializeField] UnityEngine.UI.Image coop;
    [SerializeField] UnityEngine.UI.RawImage weapon0;
    [SerializeField] UnityEngine.UI.RawImage weapon1;
    [SerializeField] UnityEngine.UI.RawImage weapon2;
    [SerializeField] UnityEngine.UI.RawImage weapon3;
    [Header("Names")]
    [SerializeField] TextMeshProUGUI reg0n;
    [SerializeField] TextMeshProUGUI reg1n;
    [SerializeField] TextMeshProUGUI ser0n;
    [SerializeField] TextMeshProUGUI ser1n;
    [SerializeField] TextMeshProUGUI op0n;
    [SerializeField] TextMeshProUGUI op1n;
    [SerializeField] TextMeshProUGUI series;
    [SerializeField] TextMeshProUGUI open;
    [SerializeField] TextMeshProUGUI coopn;

    [SerializeField] TextMeshProUGUI version;

    public Sprite[] images;
    public Sprite[] coopImages;

    private void Update()
    {
        reg0n.text = ink.stager0Name;
        reg1n.text = ink.stager1Name;
        ser0n.text = ink.stageas0Name;
        ser1n.text = ink.stageas1Name;
        op0n.text = ink.stageao0Name;
        op1n.text = ink.stageao1Name;

        reg0.sprite = images[ink.stager0];
        reg1.sprite = images[ink.stager1];
        ser0.sprite = images[ink.stageas0];
        ser1.sprite = images[ink.stageas1];
        op0.sprite = images[ink.stageao0];
        op1.sprite = images[ink.stageao1];

        series.text = ink.seriesMode;
        open.text = ink.openMode;

        coop.sprite = coopImages[ink.coopStage];
        coopn.text = ink.coopName;

        version.text = Application.version;
        
        weapon0.texture = ink.weap0;
        weapon1.texture = ink.weap1;
        weapon2.texture = ink.weap2;
        weapon3.texture = ink.weap3;

    }
}
