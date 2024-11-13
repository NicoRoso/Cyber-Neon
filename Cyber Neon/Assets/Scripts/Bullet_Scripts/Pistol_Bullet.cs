using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Bullet : MonoBehaviour
{

    public float bulletlife = 3;



    private void Awake()
    {
        Destroy(gameObject, bulletlife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy_HP>().TakeDamage(1);
            
        }
        Destroy(gameObject);
    }

    
}
