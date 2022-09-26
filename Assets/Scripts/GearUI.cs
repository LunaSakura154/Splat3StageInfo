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

    private void Update()
    {
        BrandGearName0.text = gearInfo.BrandGear0Name;
        BrandGearName1.text = gearInfo.BrandGear1Name;
        BrandGearName2.text = gearInfo.BrandGear2Name;
    }
}
