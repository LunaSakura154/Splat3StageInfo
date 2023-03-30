using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using gear;
using barbecue;

public class GearUI : MonoBehaviour
{
    [SerializeField] GearInfo gearInfo;
    [SerializeField] TextMeshProUGUI BrandGearName0;
    [SerializeField] TextMeshProUGUI BrandGearName1;
    [SerializeField] TextMeshProUGUI BrandGearName2;
    [SerializeField] TextMeshProUGUI limitGearName0;
    [SerializeField] TextMeshProUGUI limitGearName1;
    [SerializeField] TextMeshProUGUI limitGearName2;
    [SerializeField] TextMeshProUGUI limitGearName3;
    [SerializeField] TextMeshProUGUI limitGearName4;
    [SerializeField] TextMeshProUGUI limitGearName5;

    [SerializeField] RawImage BrandGearImage0;
    [SerializeField] RawImage BrandGearImage1;
    [SerializeField] RawImage BrandGearImage2;

    [SerializeField] RawImage limitGearImage0;
    [SerializeField] RawImage limitGearImage1;
    [SerializeField] RawImage limitGearImage2;
    [SerializeField] RawImage limitGearImage3;
    [SerializeField] RawImage limitGearImage4;
    [SerializeField] RawImage limitGearImage5;

    [SerializeField] RawImage[] brandPowers;
    [SerializeField] RawImage[] limitPowers;

    [SerializeField] TextMeshProUGUI[] brandPrices;
    [SerializeField] TextMeshProUGUI[] limitPrices;

    private void Update()
    {
        BrandGearName0.text = gearInfo.BrandGear0Name;
        BrandGearName1.text = gearInfo.BrandGear1Name;
        BrandGearName2.text = gearInfo.BrandGear2Name;

        limitGearName0.text = gearInfo.limit0Name;
        limitGearName1.text= gearInfo.limit1Name;
        limitGearName2.text= gearInfo.limit2Name;
        limitGearName3.text= gearInfo.limit3Name;
        limitGearName4.text= gearInfo.limit4Name;
        limitGearName5.text= gearInfo.limit5Name;

        BrandGearImage0.texture = gearInfo.brandImage0;
        BrandGearImage1.texture= gearInfo.brandImage1;
        BrandGearImage2.texture= gearInfo.brandImage2;
        limitGearImage0.texture = gearInfo.limit0Image;
        limitGearImage1.texture= gearInfo.limit1Image;
        limitGearImage2.texture= gearInfo.limit2Image;
        limitGearImage3.texture=gearInfo.limit3Image;
        limitGearImage4.texture=gearInfo.limit4Image;
        limitGearImage5.texture=gearInfo.limit5Image;

        for (int i = 0; i < brandPowers.Length; i++)
        {
            brandPowers[i].texture = gearInfo.brandPowers[i];
        }
        for (int i = 0; i < limitPowers.Length; i++)
        {
            limitPowers[i].texture = gearInfo.limitPowers[i];
        }
        for (int i = 0; i < brandPrices.Length; i++)
        {
            brandPrices[i].text = gearInfo.brandPrices[i];
        }
        for (int i = 0; i < limitPrices.Length; i++)
        {
            limitPrices[i].text = gearInfo.limitPrices[i];
        }
    }
}
