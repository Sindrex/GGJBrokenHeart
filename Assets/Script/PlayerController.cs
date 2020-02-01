﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject obj;
    public int lifes = 5;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        if (obj)
        {
            //obj.GetComponent<PlayerController>().speed = 100;
        }
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0.0f);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }

        /*
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(new Vector3(0, 1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(new Vector3(-1, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(new Vector3(0, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(new Vector3(1, 0) * speed * Time.deltaTime);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Fly"))
        {
            lifes++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            grounded = true;
        }
    }

    private void jump()
    {
        float timePassed = 0;
        grounded = false;

        while(timePassed <= 1000.0f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.0025f));
            timePassed += Time.deltaTime;
        }
    }
}
