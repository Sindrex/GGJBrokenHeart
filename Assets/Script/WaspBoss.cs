using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WaspBoss : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public Vector3 startPos;
    public float xRadius = 5;
    public float yRadius = 5;
    public int xDirection = 0;
    public int yDirection = 0;

    private int hitCounter = 0;

    public PlayerController myPlayer;

    private List<Vector3> movements;
    public Vector3 first = new Vector3(24.47f, 2.5f, 0.0f);
    public Vector3 second = new Vector3(67.61f, 2.5f, 0.0f);

    public Animator explosion;
    public BossOutro outroScript;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        movements = new List<Vector3>();
        movements.Add(first);
        movements.Add(second);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (xDirection == 1)
        {
            if (startPos.x + xRadius > transform.position.x)
            {
                transform.Translate(new Vector3(1, 0, 0) * xSpeed * Time.deltaTime);  
            }
            else
            {
                xDirection = -1;
            }
        }
        else if (xDirection == -1)
        {
            if (startPos.x - xRadius < transform.position.x)
            {
                transform.Translate(new Vector3(-1, 0, 0) * xSpeed * Time.deltaTime);
            }
            else
            {
                xDirection = 1;
            }
        }

        if (yDirection == 1)
        {
            if (startPos.y + yRadius > transform.position.y)
            {
                print(transform.position);
                transform.Translate(new Vector3(0, 1, 0) * ySpeed * Time.deltaTime);
            }
            else
            {
                yDirection = -1;
            }
        }
        else if (yDirection == -1)
        {
            if (startPos.y - yRadius < transform.position.y)
            {
                print("AAAAAAAAAAAA");
                transform.Translate(new Vector3(0, -1, 0) * ySpeed * Time.deltaTime);
            }
            else
            {
                yDirection = 1;
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
            startPos = movements[hitCounter];
            hitCounter++;
            Destroy(collision.gameObject);
            outroScript.playGlass();
        }

        if (collision.gameObject.name.Equals("FlySwatter"))
        {
            Destroy(collision.gameObject);
            //cutscene -> outro
            StartCoroutine(outro());
        }
    }

    IEnumerator outro()
    {
        explosion.gameObject.SetActive(true);
        explosion.Play("Explode");
        yield return new WaitForSeconds(0.5f);
        outroScript.play();
        this.gameObject.SetActive(false);
    }
}
