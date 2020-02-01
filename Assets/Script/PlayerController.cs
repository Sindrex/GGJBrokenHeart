using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Direction {right, left, up, down }

    public Direction imFacing;
    public float speed;
    public int lifes = 5;


    // Start is called before the first frame update
    void Start()
    {
        imFacing = Direction.right;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0.0f);

        //print(imFacing);

        if (Input.GetAxis("Horizontal") > 0)
        {
            imFacing = Direction.right;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            imFacing = Direction.left;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            imFacing = Direction.up;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            imFacing = Direction.down;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Hei");
        if (collision.gameObject.name.Equals("Fly"))
        {
            lifes++;
            Destroy(collision.gameObject);
        }
    }
}
