using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    [SerializeField] private AudioSource hpSound;
    [SerializeField] private AudioClip[] death;
    public GameObject shocke;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        hpSound.PlayOneShot(death[Random.Range(0, death.Length)]);
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Instantiate(shocke, transform.position, transform.rotation);
            CountEnemy.enemyCount--;
            Destroy(gameObject);
        }
    }

}
