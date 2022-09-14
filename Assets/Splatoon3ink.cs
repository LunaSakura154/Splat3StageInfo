using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class BankaraMatchSetting
{
    public string __isVsSetting { get; set; }
    public string __typename { get; set; }
    public List<VsStage> vsStages { get; set; }
    public VsRule vsRule { get; set; }
    public string mode { get; set; }
}

public class BankaraSchedules
{
    public List<Node> nodes { get; set; }
}

public class BigRunSchedules
{
    public List<object> nodes { get; set; }
}

public class CoopGroupingSchedule
{
    public RegularSchedules regularSchedules { get; set; }
    public BigRunSchedules bigRunSchedules { get; set; }
}

public class CoopStage
{
    public string name { get; set; }
    public int coopStageId { get; set; }
    public ThumbnailImage thumbnailImage { get; set; }
    public Image image { get; set; }
    public string id { get; set; }
}

public class CurrentPlayer
{
    public UserIcon userIcon { get; set; }
}

public class Data
{
    public RegularSchedules regularSchedules { get; set; }
    public BankaraSchedules bankaraSchedules { get; set; }
    public XSchedules xSchedules { get; set; }
    public LeagueSchedules leagueSchedules { get; set; }
    public CoopGroupingSchedule coopGroupingSchedule { get; set; }
    public FestSchedules festSchedules { get; set; }
    public object currentFest { get; set; }
    public CurrentPlayer currentPlayer { get; set; }
    //public VsStages vsStages { get; set; }
}

public class FestSchedules
{
    public List<Node> nodes { get; set; }
}

public class Image
{
    public string url { get; set; }
}

public class LeagueMatchSetting
{
    public string __isVsSetting { get; set; }
    public string __typename { get; set; }
    public List<VsStage> vsStages { get; set; }
    public VsRule vsRule { get; set; }
}

public class LeagueSchedules
{
    public List<Node> nodes { get; set; }
}

public class Node
{
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public RegularMatchSetting regularMatchSetting { get; set; }
    public object festMatchSetting { get; set; }
    public List<BankaraMatchSetting> bankaraMatchSettings { get; set; }
    public XMatchSetting xMatchSetting { get; set; }
    public LeagueMatchSetting leagueMatchSetting { get; set; }
    public Setting setting { get; set; }
    public int stageId { get; set; }
    public string id { get; set; }
    public OriginalImage originalImage { get; set; }
    public string name { get; set; }
    public object stats { get; set; }
}

public class OriginalImage
{
    public string url { get; set; }
}

public class RegularMatchSetting
{
    public string __isVsSetting { get; set; }
    public string __typename { get; set; }
    public List<VsStage> vsStages { get; set; }
    public VsRule vsRule { get; set; }
}

public class RegularSchedules
{
    public List<Node> nodes { get; set; }
}

public class Root
{
    public Data data { get; set; }
}

public class Setting
{
    public string __typename { get; set; }
    public CoopStage coopStage { get; set; }
    public List<Weapon> weapons { get; set; }
}

public class ThumbnailImage
{
    public string url { get; set; }
}

public class UserIcon
{
    public string url { get; set; }
}

public class VsRule
{
    public string name { get; set; }
    public string rule { get; set; }
    public string id { get; set; }
}

public class VsStage
{
    public string id { get; set; }
    public int vsStageId { get; set; }
    public string name { get; set; }
    public Image image { get; set; }
    public List<Node> nodes { get; set; }
}

public class Weapon
{
    public string name { get; set; }
    public Image image { get; set; }
}

public class XMatchSetting
{
    public string __isVsSetting { get; set; }
    public string __typename { get; set; }
    public List<VsStage> vsStages { get; set; }
    public VsRule vsRule { get; set; }
}

public class XSchedules
{
    public List<Node> nodes { get; set; }
}

public class Splatoon3ink : MonoBehaviour
{
    public int stager0;
    public string stager0Name;
    public int stager1;
    public string stager1Name;

    public int stageas0;
    public string stageas0Name;
    public int stageas1;
    public string stageas1Name;

    public int stageao0;
    public string stageao0Name;
    public int stageao1;
    public string stageao1Name;

    public string seriesMode;
    public string openMode;

    public int coopStage;
    public string coopName;

    public List<Node> nodesRegular;
    public List<Node> nodesAnarchy;
    public List<Node> nodesCoop;

    public float cooldown;

    
    private void Start()
    {
        GetInformation();
        //SetInformation();
    }
    public async void GetInformation()
    {
        HttpClient httpClient = new HttpClient();
        var result = await httpClient.GetAsync("https://splatoon3.ink/data/schedules.json");
        var data = JsonConvert.DeserializeObject<Root>(await result.Content.ReadAsStringAsync());
        nodesRegular = data.data.regularSchedules.nodes;
        nodesAnarchy = data.data.bankaraSchedules.nodes;
        nodesCoop = data.data.coopGroupingSchedule.regularSchedules.nodes;
        Debug.Log("Information Requested");
        SetInformation();
        await Task.Delay(-1);

    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            GetInformation();
            cooldown = 300;
        }
    }

    void SetInformation()
    {
        stager0 = nodesRegular[0].regularMatchSetting.vsStages[0].vsStageId;
        stager0Name = nodesRegular[0].regularMatchSetting.vsStages[0].name;
        stager1 = nodesRegular[0].regularMatchSetting.vsStages[1].vsStageId;
        stager1Name = nodesRegular[0].regularMatchSetting.vsStages[1].name;

        stageas0 = nodesAnarchy[0].bankaraMatchSettings[0].vsStages[0].vsStageId;
        stageas0Name = nodesAnarchy[0].bankaraMatchSettings[0].vsStages[0].name;
        stageas1 = nodesAnarchy[0].bankaraMatchSettings[0].vsStages[1].vsStageId;
        stageas1Name = nodesAnarchy[0].bankaraMatchSettings[0].vsStages[1].name;

        stageao0 = nodesAnarchy[0].bankaraMatchSettings[1].vsStages[0].vsStageId;
        stageao0Name = nodesAnarchy[0].bankaraMatchSettings[1].vsStages[0].name;
        stageao1 = nodesAnarchy[0].bankaraMatchSettings[1].vsStages[1].vsStageId;
        stageao1Name = nodesAnarchy[0].bankaraMatchSettings[1].vsStages[1].name;

        seriesMode = nodesAnarchy[0].bankaraMatchSettings[0].vsRule.name;
        openMode = nodesAnarchy[0].bankaraMatchSettings[1].vsRule.name;
        coopStage = nodesCoop[0].setting.coopStage.coopStageId;
        coopName = nodesCoop[0].setting.coopStage.name;
    }
}
