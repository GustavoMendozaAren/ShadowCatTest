using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TriggerButtons : MonoBehaviour
{
    [SerializeField]
    int identificador = 0;

    [SerializeField]
    GameObject buttonAppear;

    public MusicBridge levelMusic;

    private void Start()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        levelMusic = instanciaMusic.GetComponent<MusicBridge>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonAppear.SetActive(true);
            gameObject.SetActive(false);
            levelMusic.NotificarCambioMusica("Acorde");
        }
    }


}
