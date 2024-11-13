using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicStart : MonoBehaviour
{
    [SerializeField] private AudioSource Dj;
    [SerializeField] private AudioClip[] ost;

    void Start()
    {
        int rnd = Random.Range(0, ost.Length);

        Dj.PlayOneShot(ost[rnd]);
    }

}
