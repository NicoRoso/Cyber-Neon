using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SMG : MonoBehaviour
{
    [SerializeField] private float spread;
    [SerializeField] private float shootForce;
    [SerializeField] private float fireRate = 10;
    [SerializeField] private float nextfire = 0;

    public GameObject player;
    [SerializeField] public int ammo = 50;
    [SerializeField] private bool bonusActive = false;
    [SerializeField] private Text ammoCount;
    [SerializeField] private bool anim;

    [SerializeField] private AudioSource fire;
    [SerializeField] private AudioClip[] gunFire;
    [SerializeField] private AudioClip gunBonus;

    //[SerializeField] private ParticleSystem flashEff;

    [SerializeField] private Transform bulletSpawn;

    public GameObject bullet;

    public Camera cam;


    private void Start()
    {
        fire = GetComponent<AudioSource>();
        bonusActive = false;
        anim = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            ammo += 50;

            
        }
    }


    void Update()
    {
        ammoCount.text = "Ammo: " + ammo;

        if (Input.GetMouseButton(0) && Time.time > nextfire)
        {
            nextfire = Time.time + 1f / fireRate;
            shoot();
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
            ammo = 50;
            this.gameObject.SetActive(false);
        }
    }

    private void shoot()
    {
        //flashEff.Play();

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
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

        Vector3 dirWithoutSpread = targetPoint - bulletSpawn.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);

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

        SoundGun();
    }

    private void Bonus()
    {
        fire.PlayOneShot(gunBonus);
        player.GetComponent<Rigidbody>().AddForce(0, -1000, 0);
        bonusActive = true;
        ammoCount.text = "Ammo: 0";
    }

    private void SoundGun()
    {
        int randInd = Random.Range(0, gunFire.Length);

        fire.PlayOneShot(gunFire[randInd]);
    }
}
