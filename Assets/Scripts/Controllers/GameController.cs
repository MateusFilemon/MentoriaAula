using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameController : MonoBehaviour
{
 
    public static GameController instance;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    public void PauseUnpause()
    {
        if (isPaused)
        {

            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            isPaused = true;
        }
        
    }

    public void PauseAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseUnpause();
        }
    }


    public void GameOver()
    {
        StartCoroutine(GameOverSequence());
    }


    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
        //congela o jogo
        Time.timeScale = 0f;
    }







}
