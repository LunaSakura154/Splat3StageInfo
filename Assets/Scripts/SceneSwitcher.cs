using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void StageInfo()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void GearInfo()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void GoToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId, LoadSceneMode.Single);
    }
}
