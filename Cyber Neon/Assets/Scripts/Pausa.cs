using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausaMenuUI;
    private bool Ready;
    public int indexLevel;

    private void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause_menu();
            }
        }
    }

    public void Resume()
    {
        pausaMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    private void Pause_menu()
    {
        Cursor.visible = true;
        pausaMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(indexLevel);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
