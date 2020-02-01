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
        //hookPos = collision.transform.position;
        //hookLerp = true;
    }
}
