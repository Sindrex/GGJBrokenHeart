using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspAI : MonoBehaviour
{
    public PlayerController myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("wasp");

        if (collision.gameObject.name.Equals("Frog"))
        {
            print("wasp sting");
            GameObject gHit = collision.gameObject;
            Transform tHit = gHit.transform;
            Vector2 position = new Vector2(tHit.position.x - 1F, tHit.position.y);
            for (int i = 0; i < 5; i++)
            {
                print("in for loop");
                myPlayer.transform.position = position;
                position = new Vector2(position.x - 1F, position.y);

            }

        }
    }
}
