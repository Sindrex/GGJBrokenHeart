using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpikes: MonoBehaviour
{
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
        print("Spikes");
        if (collision.gameObject.name.Equals("Frog"))
        {
            print("you died");

            
        }
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        print("spikes trigger");
    }
}
