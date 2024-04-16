using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{

    public static Action GameSceneLoaded;
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameScene()
    {
        GameSceneLoaded?.Invoke();
        SceneManager.LoadScene("GameScene");
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("End");
    }
}