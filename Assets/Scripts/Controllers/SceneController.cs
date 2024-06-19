using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    //seleção de mapa
  //string sceneSelected;
    

    public void MainScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene(0);
    }

    public void MainMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        //SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    //seleção de mapa
    /*
    public void LoadScene(string sceneName)
    {
        sceneSelected = sceneName;
    }
    */
}
