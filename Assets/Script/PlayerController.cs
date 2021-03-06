﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public int lifes = 5;
    public Vector3 respawnPoint;
    public Vector3 boardStart;
    public bool grounded;
    public Text lifesCounter;
    public AudioSource jumpAudio;



    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        boardStart = transform.position;

        
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0.0f);
        lifesCounter.text = "" + lifes;

        if (Input.GetKey(KeyCode.Space) && grounded)
            {
                jump();
                jumpAudio.Play();
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Fly"))
        {
            lifes++;
          
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("DeathSpike"))
        {
            if(lifes < 1)
            {
                string levelName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(levelName);

            }else
            {
                transform.position = respawnPoint;
                print("you died");
                print(lifes);
                lifes--;
            }

            




        }

        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Sticky"))
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
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.01f));
            timePassed += Time.deltaTime;
        }
    }
}
