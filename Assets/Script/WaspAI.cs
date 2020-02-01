using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaspAI : MonoBehaviour
{
    public PlayerController myPlayer;
    public int direction = 1;
    public Vector3 startPos;
    public float radius = 5;
    public float speed;
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
        print("wasp");

        if (collision.gameObject.name.Equals("Frog"))
        {
            print("wasp sting");
            GameObject gHit = collision.gameObject;
            Transform tHit = gHit.transform;
            Vector2 position = new Vector2(tHit.position.x - 5F, tHit.position.y);
            myPlayer.transform.position = position;
            myPlayer.lifes--;

            if(myPlayer.lifes < 1)
            {
                string levelName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(levelName);
            }



        }
    }
}
