using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;

public class VersionCheck : MonoBehaviour
{
    [SerializeField] public string versionGit;
    [SerializeField] public string versionCurrent;

    [SerializeField] GameObject updateWindow;

    void Start()
    {
        versionCurrent = Application.version;
        CheckVer();
    }

    public void CheckVer()
    {
        string myBotNewVersionURL = "https://raw.githubusercontent.com/LunaSakura154/Splat3StageInfo/main/Version.txt";

        WebClient myBotNewVersionClient = new WebClient();
        Stream stream = myBotNewVersionClient.OpenRead(myBotNewVersionURL);
        StreamReader reader = new StreamReader(stream);
        string content = reader.ReadToEnd();

        var sb = new StringBuilder(content.Length);
        foreach (char i in content)
        {
            if (i == '\n')
            {
                sb.Append(Environment.NewLine);
            }
            else if (i != '\r' && i != '\t')
                sb.Append(i);
        }

        content = sb.ToString();

        versionGit = content;

        CompareVersion(versionGit, versionCurrent);
    }

    public void CompareVersion(string gitVer, string curVer)
    {
        if (gitVer != curVer)
        {
            updateWindow.SetActive(true);
        }
    }
}
