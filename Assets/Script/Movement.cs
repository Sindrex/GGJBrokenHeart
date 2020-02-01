using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public Vector3 startPos;
    public float xRadius = 5;
    public float yRadius = 5;
    public int xDirection = 0;
    public int yDirection = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
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
                transform.Translate(new Vector3(0, -1, 0) * ySpeed * Time.deltaTime);
            }
            else
            {
                yDirection = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
