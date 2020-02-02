using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WaspBoss : MonoBehaviour
{
    public float speed;
    public Vector3 startPos;
    public float radius = 5;
    public int direction = 1;
    public PlayerController myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (direction > 0)
        {
            if (startPos.x + radius > transform.position.x)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            }
            else
            {
                direction = -1;
            }
        }
        else
        {
            if (startPos.x - radius < transform.position.x)
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            }
            else
            {
                direction = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("wasp Boss");

        if (collision.gameObject.name.Equals("Frog"))
        {
            print("wasp sting");
            GameObject gHit = collision.gameObject;
            Transform tHit = gHit.transform;
            Vector2 position = new Vector2(tHit.position.x - 5F, tHit.position.y);
            myPlayer.transform.position = position;
            myPlayer.lifes--;

            if (myPlayer.lifes < 1)
            {
                string levelName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(levelName);
            }



        }

        if (collision.gameObject.tag.Equals("Chandelier"))
        {
            //TODO: move boss to right
        }

        if (collision.gameObject.name.Equals("FlySwatter"))
        {
            //TODO: wasp boss ded
        }
    }


}
