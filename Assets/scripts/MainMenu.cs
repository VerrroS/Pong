using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    string input;
    public bool paused = false;
    public GameObject menu;
    public Text text;
    public GameManager gameManager;

    private void Start()
    {
        input = "Cancel";
        PauseGame();

    }

    void Update()
    {
        if (Input.GetButtonDown(input))
        {
            DeterminePause();
        }
    }

    private void DeterminePause()
    {
        if (paused)
        {
            ResumGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        menu.SetActive(true);
        paused = true;
    }


    public void ResumGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;
        menu.SetActive(false);
    }


     public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
