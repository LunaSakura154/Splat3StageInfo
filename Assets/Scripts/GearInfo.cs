using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
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
        public List<LimitedGear> limitedGear;

        public string BrandGear0Name;
        public string BrandGear1Name;
        public string BrandGear2Name;
        public string limit0Name;
        public string limit1Name;
        public string limit2Name;
        public string limit3Name;
        public string limit4Name;
        public string limit5Name;
        [Space]
        public Texture brandImage0;
        public Texture brandImage1;
        public Texture brandImage2;
        public Texture limit0Image;
        public Texture limit1Image;
        public Texture limit2Image;
        public Texture limit3Image;
        public Texture limit4Image;
        public Texture limit5Image;
        [Space]
        public Texture[] brandPowers = new Texture[3];
        public Texture[] limitPowers = new Texture[6];
        [Space]
        public string[] brandPrices;
        public string[] limitPrices;

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
            limitedGear = data.data.gesotown.limitedGears;
            Debug.Log("Gear Information Requested");
            SetInformation();
            await Task.Delay(-1);

        }

        public void SetInformation()
        {
            BrandGear0Name = pickupBrand.brandGears[0].gear.name;
            BrandGear1Name = pickupBrand.brandGears[1].gear.name;
            BrandGear2Name = pickupBrand.brandGears[2].gear.name;
            limit0Name = limitedGear[0].gear.name;
            limit1Name = limitedGear[1].gear.name;
            limit2Name = limitedGear[2].gear.name;
            limit3Name = limitedGear[3].gear.name;
            limit4Name = limitedGear[4].gear.name;
            limit5Name = limitedGear[5].gear.name;
            StartCoroutine(SetGearImages());
            StartCoroutine(Powers());

            for (int i = 0; i < brandPrices.Length; i++)
            {
                brandPrices[i] = pickupBrand.brandGears[i].price.ToString();
            }
            for (int i = 0; i < limitPrices.Length; i++)
            {
                limitPrices[i] = limitedGear[i].price.ToString();
            }
        }

        public IEnumerator SetGearImages()
        {
            UnityWebRequest b0 = UnityWebRequestTexture.GetTexture(pickupBrand.brandGears[0].gear.image.url);
            UnityWebRequest b1 = UnityWebRequestTexture.GetTexture(pickupBrand.brandGears[1].gear.image.url);
            UnityWebRequest b2 = UnityWebRequestTexture.GetTexture(pickupBrand.brandGears[2].gear.image.url);
            UnityWebRequest l0 = UnityWebRequestTexture.GetTexture(limitedGear[0].gear.image.url);
            UnityWebRequest l1 = UnityWebRequestTexture.GetTexture(limitedGear[1].gear.image.url);
            UnityWebRequest l2 = UnityWebRequestTexture.GetTexture(limitedGear[2].gear.image.url);
            UnityWebRequest l3 = UnityWebRequestTexture.GetTexture(limitedGear[3].gear.image.url);
            UnityWebRequest l4 = UnityWebRequestTexture.GetTexture(limitedGear[4].gear.image.url);
            UnityWebRequest l5 = UnityWebRequestTexture.GetTexture(limitedGear[5].gear.image.url);
            yield return b0.SendWebRequest();
            yield return b1.SendWebRequest();
            yield return b2.SendWebRequest();
            yield return l0.SendWebRequest();
            yield return l1.SendWebRequest();
            yield return l2.SendWebRequest();
            yield return l3.SendWebRequest();
            yield return l4.SendWebRequest();
            yield return l5.SendWebRequest();

            brandImage0 = ((DownloadHandlerTexture)b0.downloadHandler).texture;
            brandImage1 = ((DownloadHandlerTexture)b1.downloadHandler).texture;
            brandImage2 = ((DownloadHandlerTexture)b2.downloadHandler).texture;
            limit0Image = ((DownloadHandlerTexture)l0.downloadHandler).texture;
            limit1Image = ((DownloadHandlerTexture)l1.downloadHandler).texture;
            limit2Image = ((DownloadHandlerTexture)l2.downloadHandler).texture;
            limit3Image = ((DownloadHandlerTexture)l3.downloadHandler).texture;
            limit4Image = ((DownloadHandlerTexture)l4.downloadHandler).texture;
            limit5Image = ((DownloadHandlerTexture)l5.downloadHandler).texture;
        }

        public IEnumerator Powers()
        {
            List<UnityWebRequest> requests = new List<UnityWebRequest>();
            List<UnityWebRequest> lRequests = new List<UnityWebRequest>();
            for (int i = 0; i < brandPowers.Length; i++)
            {
                UnityWebRequest a = UnityWebRequestTexture.GetTexture(pickupBrand.brandGears[i].gear.primaryGearPower.image.url);
                requests.Add(a);
            }
            for (int i = 0; i < limitPowers.Length; i++)
            {
                UnityWebRequest a = UnityWebRequestTexture.GetTexture(limitedGear[i].gear.primaryGearPower.image.url);
                lRequests.Add(a);
            }
            foreach (UnityWebRequest request in requests)
            {
                yield return request.SendWebRequest();
            }
            foreach (UnityWebRequest request in lRequests)
            {
                yield return request.SendWebRequest();
            }
            for (int i = 0; i < brandPowers.Length; i++)
            {
                brandPowers[i] = ((DownloadHandlerTexture)requests[i].downloadHandler).texture;
            }
            for (int i = 0; i < limitPowers.Length; i++)
            {
                limitPowers[i] = ((DownloadHandlerTexture)lRequests[i].downloadHandler).texture;
            }
        }
    }
}
