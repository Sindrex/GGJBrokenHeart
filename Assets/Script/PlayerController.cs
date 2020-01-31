using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0.0f);
        /*
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(new Vector3(0, 1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(new Vector3(-1, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(new Vector3(0, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(new Vector3(1, 0) * speed * Time.deltaTime);
        }*/
    }
}
