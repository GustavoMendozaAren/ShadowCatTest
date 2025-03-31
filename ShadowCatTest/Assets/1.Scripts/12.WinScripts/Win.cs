using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject[] panel;

    public GameObject Pista1Win;
    [SerializeField] private int pistaID;
    private Collider2D colliderPista;

    public MusicBridge levelMusic;

    public PlayerDamage damageInstance;

    private void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        levelMusic = instanciaMusic.GetComponent<MusicBridge>();

        GameObject playerDamageInstance = GameObject.Find("Player v3 Switcher (1)");
        damageInstance = playerDamageInstance.GetComponent<PlayerDamage>();

        StateGameController.playerCanDie = true;

        if (StateGameController.pistaAgarrada[pistaID])
        {
            Pista1Win.SetActive(false);
            colliderPista.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(WinConditionCo());

            Pista1Win.SetActive(false);
            StateGameController.pistaAgarrada[pistaID] = true;
            StateGameController.pistaCandado[pistaID] = true;

            StateGameController.playerCanDie = false;
        }
    }

    IEnumerator WinConditionCo()
    {
        damageInstance.PuedeRecibirDa�o(false);
        levelMusic.NotificarCambioMusica("Ganar");
        panel[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        panel[1].SetActive(true);
        yield return new WaitForSeconds(.5f);
        panel[2].SetActive(true);
        panel[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        //damageInstance.PuedeRecibirDa�o(true);
    }
    

}
