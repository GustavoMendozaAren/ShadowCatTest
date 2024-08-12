using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject[] panel;

    public GameObject Pista1Win;
    private int pistaID;

    public MusicBridge levelMusic;

    public PlayerDamage damageInstance;

    private void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        levelMusic = instanciaMusic.GetComponent<MusicBridge>();

        GameObject playerDamageInstance = GameObject.Find("Player v3 Switcher (1)");
        damageInstance = playerDamageInstance.GetComponent<PlayerDamage>();

        StateGameController.playerCanDie = true;

        pistaID = StateGameController.sceneNo;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(WinConditionCo());

            if (pistaID == 1)
            {
                StateGameController.pista1 = true;
                StateGameController.candado[0]++;
            }
            if (pistaID == 2)
            {
                StateGameController.pista2 = true;
                StateGameController.candado[1]++;
            }
            if (pistaID == 3)
            {
                StateGameController.pista3 = true;
                StateGameController.candado[2]++;
            }
            if (pistaID == 4)
            {
                StateGameController.pista4 = true;
                StateGameController.candado[3]++;
            }
            if (pistaID == 5)
            {
                StateGameController.pista5 = true;
                StateGameController.candado[4]++;
            }
            if (pistaID == 6)
            {
                StateGameController.pista6 = true;
                StateGameController.candado[5]++;
            }

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
