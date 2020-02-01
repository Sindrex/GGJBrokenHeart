using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TongueController : MonoBehaviour
{
    public PlayerController myPlayer;
    public Vector2 hookPos;
    public bool hookLerp;
    public float lerpFac;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 playerPos = myPlayer.transform.position;
        //float x = Mathf.Lerp(playerPos.x, hookPos.y, lerpFac);
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
            Vector2 position = new Vector2(tHit.position.x-0.3F, tHit.position.y-0.3F);
            myPlayer.transform.position = position;



        }
    }

}
