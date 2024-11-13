using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] public float time = 0;
    [SerializeField] public GameObject[] cars;

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time >= 1)
        {
            GameObject copy = Instantiate(cars[Random.Range(0, cars.Length)], transform.position, Quaternion.identity);
            Destroy(copy, 5);
            time = 0;
        }
    }
}
