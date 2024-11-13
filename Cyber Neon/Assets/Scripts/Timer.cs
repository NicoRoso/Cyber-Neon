using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private float timerStart;
    [SerializeField] public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        timer.text = timerStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timerStart += Time.deltaTime;
        timer.text = timerStart.ToString("F2");
    }
}
