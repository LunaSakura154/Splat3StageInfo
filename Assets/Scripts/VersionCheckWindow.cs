using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VersionCheckWindow : MonoBehaviour
{
    [SerializeField] private VersionCheck check;
    [SerializeField] private TextMeshProUGUI uGUI;
    private void Start()
    {
        check = FindObjectOfType<VersionCheck>();

        uGUI.text = $"Version does not match latest: ({check.versionGit})";
    }

    public void Download()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1l749zW0BR8PrLZ8vd_dlCsjsoQVPfdS3?usp=sharing");
    }
}
