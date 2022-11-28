using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Red : MonoBehaviour
{
    private float timer;
    public GameObject Player;
    public GameObject Bullet;
    public GameObject Gun;
    // Use this for initialization
    void Start () {
        
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
        timer += 1 * Time.deltaTime;
        if (timer >= 2f) {
            GameObject a1 = (GameObject)Instantiate(Bullet, Gun.transform.position, transform.rotation);
            timer = 0;
        }
    }
}