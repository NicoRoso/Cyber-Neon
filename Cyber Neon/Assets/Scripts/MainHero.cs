using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHero : MonoBehaviour
{
    [SerializeField] private float _speed;
    public GameObject Camera;
    private float cx;
    private float cy;
    bool OnGround;
    [SerializeField] private float mouseSensivity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Ground") 
        {
            OnGround = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cx+=Input.GetAxis ("Mouse X")*mouseSensivity*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, cx, 0);
        cy-=Input.GetAxis ("Mouse Y")*mouseSensivity*Time.deltaTime;
        cy = Mathf.Clamp (cy, -90,90);
        Camera.transform.rotation = Quaternion.Euler(cy,cx,0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate( 0, 0, _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate( 0, 0, _speed * Time.deltaTime * -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate( _speed * Time.deltaTime * -1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate( _speed * Time.deltaTime, 0, 0);
        }
        Jump();
    }

    void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && OnGround == true)
        {
            OnGround = false;
            GetComponent<Rigidbody>().AddForce(0, 400, 0);
        }
    }
}
