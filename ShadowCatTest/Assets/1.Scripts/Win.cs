using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject[] panel;

    public GameObject Pista1Win;

    public MusicBridge levelMusic;

    public PlayerDamage damageInstance;
    private void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        levelMusic = instanciaMusic.GetComponent<MusicBridge>();

        GameObject playerDamageInstance = GameObject.Find("Player v3 Switcher (1)");
        damageInstance = playerDamageInstance.GetComponent<PlayerDamage>();

        StateGameController.playerCanDie = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(WinConditionCo());
            StateGameController.pista1 = true;
            StateGameController.level2Key = true;
            Pista1Win.SetActive(false);

            StateGameController.playerCanDie = false;
        }
    }

    IEnumerator WinConditionCo()
    {
        damageInstance.PuedeRecibirDaño(false);
        levelMusic.NotificarCambioMusica("Ganar");
        panel[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        panel[1].SetActive(true);
        yield return new WaitForSeconds(.5f);
        panel[2].SetActive(true);
        panel[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        //damageInstance.PuedeRecibirDaño(true);
    }
    

}
