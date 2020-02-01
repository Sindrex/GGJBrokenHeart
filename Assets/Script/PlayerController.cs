﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int lifes = 5;
    public Vector3 respawnPoint;
    public bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0.0f);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Fly"))
        {
            lifes++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("DeathSpike"))
        {
            if(lifes < 2)
            {
                print("you died");
            }else
            {
                lifes--;
                transform.position = respawnPoint;
            }
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
