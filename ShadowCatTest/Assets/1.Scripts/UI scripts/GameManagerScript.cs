using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject pauseButton;
    public GameObject[] deadPanel;
    public GameObject[] fotosSprites;

    public MusicBridge levelMusic;

    [HideInInspector]
    public bool playerIsDead = false;

    private bool cambioFoto = false;

    //IEnumerator deadCoroutine;

    private void Start()
    {
        //    deadCoroutine = DeadCorutine();
        GameObject instanciaMusic = GameObject.Find("Music");
        levelMusic = instanciaMusic.GetComponent<MusicBridge>();
    }

    private void Update()
    {
        PlayerDead(playerIsDead);
    }

    public void Restart()
    {
        levelMusic.NotificarCambioMusica("Pausa", false);
        levelMusic.NotificarCambioMusica("EsGato", false);
        SceneManager.LoadScene("SampleScene Jacob");       
        Time.timeScale = 1f;
    }

    public void MenuOption()
    {
        levelMusic.DestroyMusic();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    //PauseSection

    public void PauseButton()
    {
        PausePanel.SetActive(true);        
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        levelMusic.NotificarCambioMusica("Pausa", true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        PausePanel.SetActive(false);
        pauseButton.SetActive(true);
        levelMusic.NotificarCambioMusica("Pausa", false);
        Time.timeScale = 1f;
    }

    public void FotoCambioSprites()
    {
        cambioFoto = !cambioFoto;

        if (cambioFoto)
        {
            fotosSprites[0].SetActive(false);
            fotosSprites[1].SetActive(true);

        }
        else if (!cambioFoto)
        {
            fotosSprites[0].SetActive(true);
            fotosSprites[1].SetActive(false);
        }
    }
    IEnumerator DeadCorutine()
    {
        deadPanel[0].SetActive(true);
        yield return new WaitForSeconds(3f);
        deadPanel[1].SetActive(true);
        deadPanel[2].SetActive(true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }


    public void PlayerDead(bool playerDead)
    {
        if (playerDead)
        {
            StartCoroutine(DeadCorutine());
        }
    }
}
