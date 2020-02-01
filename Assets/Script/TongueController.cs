using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
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
        print("Hei");
        if (collision.gameObject.name.Equals("Fly"))
        {
            myPlayer.lifes++;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag.Equals("HookShotAnchor"))
        {
            print("SLUUURP");
            GameObject gHit = collision.gameObject;
            Transform tHit = gHit.transform;
            Vector2 position = new Vector2(tHit.position.x, tHit.position.y-0.3F);
            Debug.Log(position);
            myPlayer.transform.position = position;



        }
    }

}
