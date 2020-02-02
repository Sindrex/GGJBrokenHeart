using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public Animator princess;
    public GameObject princess2;
    public Animator heart;
    public Animator waspKing;
    public Animator heartLeft;
    public Animator heartRight;
    public Animator frog;
    public AudioSource tongue;
    public GameObject title;
    public Animator explode;
    public GameObject flyQueen;
    public GameObject quit;

    bool ok = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("IntroCut"))
        {
            StartCoroutine(introCut());
        }
        else if (SceneManager.GetActiveScene().name.Equals("OutroCut"))
        {
            StartCoroutine(outroCut());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ok)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Application.Quit();
            }
        }
    }

    IEnumerator outroCut()
    {
        frog.Play("OutroCut");
        frog.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.1f);
        heartRight.gameObject.SetActive(true);
        heartRight.Play("RightOutro");
        tongue.Play();
        yield return new WaitForSeconds(1f);
        heartLeft.gameObject.SetActive(true);
        tongue.Play();
        heartLeft.Play("LeftOutro");
        yield return new WaitForSeconds(1f);
        heartLeft.gameObject.SetActive(false);
        heartRight.gameObject.SetActive(false);
        heart.gameObject.SetActive(true);
        heart.Play("ExplodeAnimBackwards");
        yield return new WaitForSeconds(4f);
        princess2.SetActive(false);
        princess.gameObject.SetActive(true);
        princess.Play("OutroAnim");
        yield return new WaitForSeconds(2f);
        explode.gameObject.SetActive(true);
        explode.Play("Explode");
        yield return new WaitForSeconds(0.5f);
        princess.gameObject.SetActive(false);
        flyQueen.SetActive(true);
        yield return new WaitForSeconds(4f);
        frog.Play("OutroCut2");
        frog.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        flyQueen.SetActive(false);
        tongue.Play();
        yield return new WaitForSeconds(1.5f);
        frog.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        quit.SetActive(true);
        ok = true;
    }

    IEnumerator introCut()
    {
        princess.Play("IntroAnim");
        yield return new WaitForSeconds(1f);
        princess2.SetActive(true);
        princess.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        heart.gameObject.SetActive(true);
        heart.Play("JumpAnim");
        yield return new WaitForSeconds(2.3f);
        heart.gameObject.transform.position += new Vector3(0, -2, 0);
        waspKing.gameObject.SetActive(true);
        waspKing.Play("FlyWaspKing");
        yield return new WaitForSeconds(4f);
        heart.Play("ExplodeAnim");
        yield return new WaitForSeconds(1.2f);
        waspKing.Play("FlyWaspKing2");
        heart.gameObject.SetActive(false);
        heartLeft.gameObject.SetActive(true);
        heartRight.gameObject.SetActive(true);
        heartRight.Play("RightFollow");
        yield return new WaitForSeconds(4f);
        waspKing.gameObject.SetActive(false);
        heartRight.gameObject.SetActive(false);
        heartLeft.Play("LeftDown");
        yield return new WaitForSeconds(3f);
        frog.gameObject.SetActive(true);
        frog.Play("IntroCut");
        frog.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        heartLeft.gameObject.SetActive(false);
        tongue.Play();
        yield return new WaitForSeconds(0.5f);
        frog.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        title.SetActive(true);
        tongue.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level 1");
    }
}
