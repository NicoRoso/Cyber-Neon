using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{

    public float bulletlife = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward* Time.deltaTime* 40;
    }

    private void Awake()
    {
        Destroy(gameObject, bulletlife);
    }
}
