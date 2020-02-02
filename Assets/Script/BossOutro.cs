using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossOutro : MonoBehaviour
{
    public Animator heart;
    bool lerp = false;
    public float a = 0;
    public SpriteRenderer blackFrog;

    public AudioSource glass;

    // Start is called before the first frame update
    void Start()
    {
        //play();
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGlass()
    {
        glass.Play();
    }

    public void play()
    {
        heart.gameObject.SetActive(true);
        heart.Play("RightBoss");
        StartCoroutine(wait());
    }

    void lerping()
    {
        print("repeating");
        print(a);
        print("Ahlpha: " + blackFrog.color.a);
        if (blackFrog.color.a < 1)
        {
            //a += 0.1f;
            blackFrog.color += new Color(0, 0, 0, a);
        }
        else if (blackFrog.color.a >= 1)
        {
            print("Start");
            SceneManager.LoadScene("OutroCut");
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        InvokeRepeating("lerping", 0.1f, 0.1f);
        a = 0.1f;
    }

}
