using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainHero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float mouseSensivity;

    [SerializeField] public int indexLevel;

    [Header("Canvas")]
    public GameObject Camera;
    public GameObject Death;
    public GameObject Hud;
    public GameObject StartTitle;

    private float cx;
    private float cy;

    public static int hp = 1;

    bool OnGround;

    [Header("Weapon")]
    public List<GameObject> unlockedWeapons;
    public GameObject[] allweapons; 
    
    [Header("Sounds")]
    [SerializeField] private AudioClip[] deathSounds;
    [SerializeField] private AudioClip[] footstep;
    [SerializeField] private AudioClip PickUp;
    private AudioSource playerAudio;
    


    //public Image weaponIcon;

    
    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        Cursor.visible = false;
        playerAudio = GetComponent<AudioSource>();
        StartTitle.SetActive(true);
        Time.timeScale = 0;
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnGround = true;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            for(int i = 0; i < allweapons.Length; i++)
            {

                if (other.name == allweapons[i].name)
                {
                    unlockedWeapons.Add(allweapons[i]);
                }
            }
            playerAudio.PlayOneShot(PickUp);
            SwitchWeapon();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bullet_Enemy")
        {
            DeathSound();
            hp -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale == 0)
        {
            StartTitle.SetActive(false);
            Time.timeScale = 1;
            Hud.SetActive(true);
            Cursor.visible = false;
        }

        if (hp <= 0)
        {
            DeathTitle();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(indexLevel);
        }

        cx +=Input.GetAxis ("Mouse X")*mouseSensivity*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, cx, 0);
        cy-=Input.GetAxis ("Mouse Y")*mouseSensivity*Time.deltaTime;
        cy = Mathf.Clamp (cy, -90,90);
        Camera.transform.rotation = Quaternion.Euler(cy,cx,0);

        if (Input.GetKey(KeyCode.W))
        {         
            transform.Translate( 0, 0, _speed * Time.deltaTime);
            if (!playerAudio.isPlaying && OnGround == true)
            {
                footsteps();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {         
            transform.Translate( 0, 0, _speed * Time.deltaTime * -1);
            if (!playerAudio.isPlaying && OnGround == true)
            {
                footsteps();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {            
            transform.Translate( _speed * Time.deltaTime * -1, 0, 0);
            if (!playerAudio.isPlaying && OnGround == true)
            {
                footsteps();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate( _speed * Time.deltaTime, 0, 0);
            if (!playerAudio.isPlaying && OnGround == true)
            {
                footsteps();
            }
        }
        
        Jump();

        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            SwitchWeapon();
        }
    }

    void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && OnGround == true)
        {
            OnGround = false;
            GetComponent<Rigidbody>().AddForce(0, 400, 0);
        }
    }

    public void SwitchWeapon()
    {
        for (int i = 0; i < unlockedWeapons.Count; i++)
        {
            if (unlockedWeapons[i].activeInHierarchy)
            {
                unlockedWeapons[i].SetActive(false);
                if (i != 0)
                {
                    unlockedWeapons[i - 1].SetActive(true);
                    //weaponIcon.sprite = unlockedWeapons[i-1].GetComponent<Sprite>().sprite;
                }
                else
                {
                    unlockedWeapons[unlockedWeapons.Count - 1].SetActive(true);
                    //weaponIcon.sprite = unlockedWeapons[unlockedWeapons.Count - 1].GetComponent<Sprite>().sprite;
                }
                //weaponIcon.SetNativeSize();
                break;
            }
        }
    }

    public void DeathTitle()
    {
        Death.SetActive(true);
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(indexLevel);
        }

        Hud.SetActive(false);
    }

    void DeathSound()
    {
        int randInd = Random.Range(0, deathSounds.Length);

        playerAudio.PlayOneShot(deathSounds[randInd]);
    }

    void footsteps()
    {
        int randInd = Random.Range(0, footstep.Length);

        playerAudio.PlayOneShot(footstep[randInd]);
    }

}
