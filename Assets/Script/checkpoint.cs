using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
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
        print("checkpoint");

        if (collision.gameObject.name.Equals("Frog"))
        {
            print("Checkpoint hit");
            myPlayer.respawnPoint = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
