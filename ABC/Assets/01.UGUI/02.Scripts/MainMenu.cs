using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}
