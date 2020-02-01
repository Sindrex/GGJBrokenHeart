using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAI : MonoBehaviour
{
    public float speed;
    public Vector3 startPos;
    public float radius = 5;
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if(direction > 0)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
