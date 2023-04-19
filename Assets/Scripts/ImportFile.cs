using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.Collections;
using System.Linq;

public class ImportFile : MonoBehaviour
{
    [SerializeField] RawImage target;


    public async void SelectFile()
    {
        StartCoroutine(fileSelection());
    }

    public IEnumerator fileSelection()
    {
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Images", ".jpg", ".png"));
        FileBrowser.AddQuickLink("Pictures", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, allowMultiSelection: false, initialPath:Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        Debug.Log(FileBrowser.Success);
        if (FileBrowser.Success)
        {
            ApplyFile(FileBrowser.Result.First());
        }
    }
    public void ApplyFile(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);

        Texture2D loadTexture = new Texture2D(1, 1);
        loadTexture.LoadImage(bytes);

        target.texture = loadTexture;
    }
}
