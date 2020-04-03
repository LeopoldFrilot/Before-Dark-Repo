using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // External sources

    // Variables for scenes
    string settingsScn = "Settings Screen";
    string loseScn = "Lose Screen";
    string winScn = "Win Screen";

    private void Start()
    {
    }
    public void LoadParticularScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    // Loads next level based on File->Build Settings scene order
    public void LoadNextLevel()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene + 1);
    }
    public int GetCurrSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadIntro()
    {
        SceneManager.LoadScene(0);
    }

    // Scenes from the 'Misc Scenes' folder that don't really follow a reliable flow
    public void LoadSettingsScreen()
    {
        SceneManager.LoadScene(settingsScn);
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene(loseScn);
    }
    public void LoadWinScreen()
    {
        SceneManager.LoadScene(winScn);
    }
    // Add any other scenes in this fashion that appear in the 'Misc Scenes' folder


    public void Quit()
    {
        Application.Quit();
    }
}
