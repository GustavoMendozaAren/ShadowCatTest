using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] buttonsDetective, buttonsCat;

    public GameObject[] skipTutorial;

    public GameObject[] Texts;

    public GameObject[] Bullets, Boundries;

    private IEnumerator Detective, Cat, BulletsCo;

    public Animator anim;

    private void Start()
    {
        
        Detective = TextsTime();
        Cat = TextsTimeCat();
        BulletsCo = BulletsCourutine();
        StartCoroutine(Detective);
    }

    IEnumerator TextsTime()
    {
        yield return new WaitForSeconds(5f);
        Texts[3].SetActive(true);
        yield return new WaitForSeconds(4.7f);
        Texts[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Texts[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Texts[2].SetActive(true);
        yield return new WaitForSeconds(2f);
        buttonsDetective[0].SetActive(true);
        yield return new WaitForSeconds(.6f);
        Texts[4].SetActive(true);
        yield return new WaitForSeconds(4.1f);
        buttonsDetective[1].SetActive(true);
        yield return new WaitForSeconds(.6f);
        Texts[5].SetActive(true);
        yield return new WaitForSeconds(4.1f);
        buttonsDetective[2].SetActive(true);
        yield return new WaitForSeconds(.6f);
        Texts[6].SetActive(true);
        yield return new WaitForSeconds(4.1f);
        buttonsDetective[3].SetActive(true);
        yield return new WaitForSeconds(.6f);
        Texts[8].SetActive(true);
        yield return new WaitForSeconds(4.1f);
        buttonsDetective[4].SetActive(true);
        yield return new WaitForSeconds(.6f);
        Texts[9].SetActive(true);

    }

    IEnumerator TextsTimeCat()
    {
        yield return new WaitForSeconds(1.5f);
        buttonsCat[0].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        Texts[10].SetActive(true);
        yield return new WaitForSeconds(4.1f);
        buttonsCat[1].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        Texts[11].SetActive(true);
        yield return new WaitForSeconds(6.5f);
        buttonsCat[2].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        Texts[13].SetActive(true);
        yield return new WaitForSeconds(4.1f);
        StartCoroutine(BulletsCo);
    }

    IEnumerator BulletsCourutine()
    {
        Bullets[0].SetActive(true);
        Bullets[2].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Boundries[0].SetActive(false);
        Bullets[1].SetActive(true);
        Bullets[3].SetActive(true);
        yield return new WaitForSeconds(3f);
        skipTutorial[0].SetActive(false);
        skipTutorial[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        skipTutorial[3].SetActive(true);

    }
    public void SkipTutorial()
    {
        skipTutorial[0].SetActive(false);
        anim.SetBool("Active", true);
    }

    public void SkipYes()
    {
        SceneManager.LoadScene("SampleScene Jacob");
        Time.timeScale = 1f;
    }

    public void SkipNo()
    {
        anim.SetBool("Active", false);
        Time.timeScale = 1f;
    }

    public void ShootButton()
    {
        Texts[7].SetActive(true);
    }

    public void TransformDeactivate()
    {
        Texts[9].SetActive(false);
        StartCoroutine(Cat);
    }

    public void JumpButtonCat()
    {
        Texts[11].SetActive(false);
        Texts[12].SetActive(true);
    }

    public void TransfromDeactivateCat()
    {
        Texts[13].SetActive(false);
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
        Time.timeScale = 1f;
    }

    /*private void OnDestroy()
    {
        StopCoroutine(Detective);
        StopCoroutine(Cat);
        StopCoroutine(BulletsCo);
    }*/
}