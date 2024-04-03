using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour, IMusicObserved
{
    public GameObject[] panel;

    public GameObject Pista1Win;

    public MusicBehaviour MusicBehaviourInstance { get; set; }
    public IMusicObserver MusicObserverInstance { get; set; }

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
        GameObject music = GameObject.Find("Music");
        MusicBehaviourInstance = music.GetComponent<MusicBehaviour>();
        MusicObserverInstance = MusicBehaviourInstance;
    }
    //*******Notificar cambios para la música *******

    #region Notificar cambios de música.
    public void MusicNotificarTransformGato(bool isCat)
    {
        MusicObserverInstance.OnPlayerTransformed(isCat);
    }
    public void MusicNotificarRalentizado(bool estaRalentizando)
    {
        MusicObserverInstance.OnSlowMotionEnabled(estaRalentizando);
    }
    public void MusicNotificarPausa(bool estaPausado)
    {
        MusicObserverInstance.OnGamePaused(estaPausado);
    }
    public void MusicNotificarFinJuego(int estadoJuego)
    {
        MusicObserverInstance.OnGameStateChanged(estadoJuego); // 0 = en juego, 1 = Victoria, 2 = Derrota. 
    }
    #endregion
}
