using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private int indexLevel;
    [SerializeField] private int thisLevel;

    [SerializeField] public GameObject Score;
    [SerializeField] public GameObject Timer;


    [SerializeField] public Text textTimer;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Score.SetActive(true);
            textTimer.text = "Your time: " + Timer.GetComponent<Timer>().timer.text;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(indexLevel);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(thisLevel);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
