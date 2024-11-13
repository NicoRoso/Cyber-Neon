using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountEnemy : MonoBehaviour
{

    public GameObject finish;

    [SerializeField] public static int enemyCount;

    [SerializeField] private Text count;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 10;
        finish.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        count.text = "Droids: " + enemyCount;
        if (enemyCount <= 0)
        {
            finish.SetActive(true);
        }
    }
}
