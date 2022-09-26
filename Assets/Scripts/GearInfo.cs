using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

namespace gear
{
    public class AdditionalGearPower
    {
        public string name { get; set; }
        public Image image { get; set; }
    }

    public class Brand
    {
        public string name { get; set; }
        public UsualGearPower usualGearPower { get; set; }
        public string id { get; set; }
        public Image image { get; set; }
    }

    public class BrandGear
    {
        public string id { get; set; }
        public DateTime saleEndTime { get; set; }
        public int price { get; set; }
        public Gear gear { get; set; }
    }

    public class Data
    {
        public Gesotown gesotown { get; set; }
    }

    public class Gear
    {
        public string __typename { get; set; }
        public string name { get; set; }
        public PrimaryGearPower primaryGearPower { get; set; }
        public List<AdditionalGearPower> additionalGearPowers { get; set; }
        public Image image { get; set; }
        public Brand brand { get; set; }
    }

    public class Gesotown
    {
        public PickupBrand pickupBrand { get; set; }
        public List<LimitedGear> limitedGears { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
    }

    public class LimitedGear
    {
        public string id { get; set; }
        public DateTime saleEndTime { get; set; }
        public int price { get; set; }
        public Gear gear { get; set; }
    }

    public class NextBrand
    {
        public string name { get; set; }
        public Image image { get; set; }
        public string id { get; set; }
    }

    public class PickupBrand
    {
        public Image image { get; set; }
        public Brand brand { get; set; }
        public DateTime saleEndTime { get; set; }
        public List<BrandGear> brandGears { get; set; }
        public NextBrand nextBrand { get; set; }
    }

    public class PrimaryGearPower
    {
        public string name { get; set; }
        public Image image { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }

    public class UsualGearPower
    {
        public string name { get; set; }
        public string desc { get; set; }
        public Image image { get; set; }
    }



    public class GearInfo : MonoBehaviour
    {
        public PickupBrand pickupBrand;
        
        public string BrandGear0Name;
        public string BrandGear1Name;
        public string BrandGear2Name;

        private void Start()
        {
            GetInformation();
        }
        public async void GetInformation()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync("https://splatoon3.ink/data/gear.json");
            var data = JsonConvert.DeserializeObject<Root>(await result.Content.ReadAsStringAsync());
            pickupBrand = data.data.gesotown.pickupBrand;
            Debug.Log("Gear Information Requested");
            SetInformation();
            await Task.Delay(-1);

        }

        public void SetInformation()
        {
            BrandGear0Name = pickupBrand.brandGears[0].gear.name;
            BrandGear1Name = pickupBrand.brandGears[1].gear.name;
            BrandGear2Name = pickupBrand.brandGears[2].gear.name;
        }
    }
}
