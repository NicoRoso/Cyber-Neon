using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Red : MonoBehaviour
{
    private float timer;
    public GameObject Player;
    public GameObject Bullet;
    public GameObject Gun;

    private int target = 0;

    [SerializeField] private AudioSource enemySound;
    [SerializeField] private AudioClip[] spotted;
    [SerializeField] private AudioClip[] blaster;
    // Use this for initialization
    void Start () {
        enemySound = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player") {
            
            Player = col.gameObject;
            gameObject.GetComponent<Animator> ().SetBool ("Fire", true);
            transform.LookAt (col.transform.position);
            transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
            onFire ();
            if (target == 0)
            {
                int rnd = Random.Range(0, spotted.Length);
                enemySound.PlayOneShot(spotted[rnd]);
                target++;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            gameObject.GetComponent<Animator> ().SetBool ("Fire", false);
        }
    }
    void onFire()
    {
        timer += 0.9f * Time.deltaTime;
        if (timer >= 1f) {
            enemySound.PlayOneShot(blaster[Random.Range(0, blaster.Length)]);
            GameObject a1 = (GameObject)Instantiate(Bullet, Gun.transform.position, transform.rotation);
            timer = 0;
        }
    }
}