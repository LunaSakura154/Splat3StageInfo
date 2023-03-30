using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInfo : MonoBehaviour
{
    [SerializeField] Splatoon3ink ink;
    [SerializeField] bool festMode;
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
    [SerializeField] UnityEngine.UI.Image fest0;
    [SerializeField] UnityEngine.UI.Image fest1;
    [SerializeField] UnityEngine.UI.RawImage tri;
    [SerializeField] UnityEngine.UI.RawImage fweapon0;
    [SerializeField] UnityEngine.UI.RawImage fweapon1;
    [SerializeField] UnityEngine.UI.RawImage fweapon2;
    [SerializeField] UnityEngine.UI.RawImage fweapon3;
    [SerializeField] UnityEngine.UI.Image fcoop;



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
    [SerializeField] TextMeshProUGUI fest0n;
    [SerializeField] TextMeshProUGUI fest1n;
    [SerializeField] TextMeshProUGUI trin;
    [SerializeField] TextMeshProUGUI fcoopn;
    [SerializeField] TextMeshProUGUI king;
    [SerializeField] TextMeshProUGUI fking;


    [Header("Misc")]
    [SerializeField] TextMeshProUGUI version;
    [SerializeField] TextMeshProUGUI timeRegu;
    [SerializeField] TextMeshProUGUI timeCoop;
    [SerializeField] TextMeshProUGUI timeFest;
    [SerializeField] TextMeshProUGUI timeTri;
    [SerializeField] TextMeshProUGUI timeFestStage;
    [SerializeField] TextMeshProUGUI timeFestCoop;
    [SerializeField] GameObject normalUI;
    [SerializeField] GameObject festUI;
    [SerializeField] Texture placeholder;


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

        //reg0.sprite = images[ink.stager0];
        //reg1.sprite = images[ink.stager1];
        //ser0.sprite = images[ink.stageas0];
        //ser1.sprite = images[ink.stageas1];
        //op0.sprite = images[ink.stageao0];
        //op1.sprite = images[ink.stageao1];

        reg0.sprite = Sprite.Create(ToTexture2D(ink.sr0),new Rect(0,0, ink.sr0.width, ink.sr0.height),new Vector2(0,0));
        reg1.sprite = Sprite.Create(ToTexture2D(ink.sr1), new Rect(0, 0, ink.sr1.width, ink.sr1.height), new Vector2(0, 0));
        ser0.sprite = Sprite.Create(ToTexture2D(ink.sas0),new Rect(0,0, ink.sas0.width, ink.sas0.height),new Vector2(0,0));
        ser1.sprite = Sprite.Create(ToTexture2D(ink.sas1),new Rect(0,0, ink.sas1.width, ink.sas1.height),new Vector2(0,0));
        op0.sprite = Sprite.Create(ToTexture2D(ink.sao0),new Rect(0,0, ink.sao0.width, ink.sao0.height),new Vector2(0,0));
        op1.sprite = Sprite.Create(ToTexture2D(ink.sao1), new Rect(0, 0, ink.sao1.width, ink.sao1.height), new Vector2(0, 0));

        series.text = ink.seriesMode;
        open.text = ink.openMode;

        coop.sprite = Sprite.Create(ToTexture2D(ink.coop0), new Rect(0, 0, ink.coop0.width, ink.coop0.height), new Vector2(0, 0));
        coopn.text = ink.coopName;
        fcoop.sprite = Sprite.Create(ToTexture2D(ink.coop0), new Rect(0, 0, ink.coop0.width, ink.coop0.height), new Vector2(0, 0)); ;
        fcoopn.text = coopn.text;
        king.text = ink.SalmonKing;
        fking.text = king.text;

        version.text = Application.version;

        weapon0.texture = ink.weap0;
        weapon1.texture = ink.weap1;
        weapon2.texture = ink.weap2;
        weapon3.texture = ink.weap3;
        fweapon0.texture = weapon0.texture;
        fweapon1.texture = weapon1.texture;
        fweapon2.texture = weapon2.texture;
        fweapon3.texture = weapon3.texture;


        timeRegu.text = new string(ink.timeRegS + " - " + ink.timeRegE);
        timeCoop.text = new string(ink.timeCoopS + " - " + ink.timeCoopE);
        timeFest.text = new string(ink.timeFestS + " - " + ink.timeFestE);
        timeTri.text = new string(ink.timeFestM + " - " + ink.timeFestE);
        timeFestStage.text = timeRegu.text;
        timeFestCoop.text = timeCoop.text;

        fest0.sprite = Sprite.Create(ToTexture2D(ink.fest0), new Rect(0, 0, ink.fest0.width, ink.fest0.height), new Vector2(0, 0)); ;
        fest0n.text = ink.stagef0Name;
        fest1.sprite = Sprite.Create(ToTexture2D(ink.fest1), new Rect(0, 0, ink.fest1.width, ink.fest1.height), new Vector2(0, 0));
        fest1n.text = ink.stagef1Name;
        tri.texture = ink.stageTri;
        trin.text = ink.stageTriName;

        if(ink.stageTri == null)
        {
            tri.texture = placeholder;
        }

        festMode = ink.festMode;

        if (festMode)
        {
            festUI.SetActive(true);
            normalUI.SetActive(false);
        }
        else
        {
            festUI.SetActive(false);
            normalUI.SetActive(true);
        }
    }

    public static Texture2D ToTexture2D(Texture texture)
    {
        return Texture2D.CreateExternalTexture(
            texture.width,
            texture.height,
            TextureFormat.RGB24,
            false, false,
            texture.GetNativeTexturePtr());
    }
}
