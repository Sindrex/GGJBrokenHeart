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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(introCut());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        heartRight.gameObject.SetActive(false);
        heartLeft.Play("LeftDown");
        yield return new WaitForSeconds(3f);
        frog.gameObject.SetActive(true);
        frog.Play("IntroCut");
        yield return new WaitForSeconds(1.5f);
        heartLeft.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level 1");
    }
}
