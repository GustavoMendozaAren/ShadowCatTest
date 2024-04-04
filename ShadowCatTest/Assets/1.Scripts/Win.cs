using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject[] panel;

    public GameObject Pista1Win;

    public MusicBehaviour musicBehaviour;
    private IMusicObserver musicObserver;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(WinConditionCo());
            StateGameController.pista1 = true;
            StateGameController.level2Key = true;
            Pista1Win.SetActive(false);
        }
    }

    IEnumerator WinConditionCo()
    {
        MusicNotificarFinJuego(1);
        panel[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        panel[1].SetActive(true);
        yield return new WaitForSeconds(.5f);
        panel[2].SetActive(true);
        panel[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
    private void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        musicBehaviour = instanciaMusic.GetComponent<MusicBehaviour>();
        musicObserver = musicBehaviour;
    }
    public void MusicNotificarFinJuego(int estadoJuego)
    {
        musicObserver.OnGameStateChanged(estadoJuego); // 0 = en juego, 1 = Victoria, 2 = Derrota. 
    }

}
