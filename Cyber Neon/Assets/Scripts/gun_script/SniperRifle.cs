using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Authentication.ExtendedProtection;

public class SniperRifle : MonoBehaviour
{

    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;

    public GameObject player;
    [SerializeField] public int ammo = 6;
    [SerializeField] private bool bonusActive = false;
    [SerializeField] private Text ammoCount;
    [SerializeField] private bool anim;


    public float shootForce;
    public float spread;

    [SerializeField] public AudioClip[] gunFire;
    [SerializeField] private AudioClip gunBonus;

    private AudioSource playerGun;

    // Start is called before the first frame update
    void Start()
    {
        playerGun = GetComponent<AudioSource>();
        bonusActive = false;
        anim = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            ammo += 6;


        }
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount.text = "Ammo: " + ammo;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            ammo--;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Bonus();
        }
        if (ammo <= 0 || bonusActive == true)
        {
            

            for (int i = 0; i < player.GetComponent<MainHero>().unlockedWeapons.Count; i++)
            {
                player.GetComponent<MainHero>().unlockedWeapons.RemoveAt(1);
            }
            player.GetComponent<MainHero>().unlockedWeapons[0].SetActive(true);
            bonusActive = false;
            ammo = 6;
            this.gameObject.SetActive(false);
        }
    }

    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        if (anim == false)
        {
            anim = true;
            GetComponent<Animator>().SetBool("fire", true);
        }
        else
        {
            anim = false;
            GetComponent<Animator>().SetBool("fire", false);
        }

        playerGun.PlayOneShot(gunFire[0]);
    }

    private void Bonus()
    {
        playerGun.PlayOneShot(gunBonus);
        player.GetComponent<Rigidbody>().AddForce(0, 0, 1000);
        bonusActive = true;
        ammoCount.text = "Ammo: 0"; 
        
    }

}
