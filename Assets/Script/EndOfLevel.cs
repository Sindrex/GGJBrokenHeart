using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    public string NEXT_LEVEL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("TRIGGERED!");
        if (other.gameObject.name.Equals("Frog"))
        {
            print("FINISHED!");
            SceneManager.LoadScene(NEXT_LEVEL);
        }
    }
}
