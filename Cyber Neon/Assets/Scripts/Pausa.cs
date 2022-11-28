using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausaMenuUI;

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
        pausaMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
